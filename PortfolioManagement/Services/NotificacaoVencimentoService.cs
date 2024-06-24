using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortfolioManagement.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PortfolioManagement.Services
{
    public class NotificacaoVencimentoService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _provider;
        private Timer _timer;

        public NotificacaoVencimentoService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(EnviarNotificacoes, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private async void EnviarNotificacoes(object state)
        {
            using (var scope = _provider.CreateScope())
            {
                var produtoService = scope.ServiceProvider.GetRequiredService<IProdutoFinanceiroService>();
                var emailService = scope.ServiceProvider.GetRequiredService<EmailService>();
                var produtos = await produtoService.GetProdutosProximosVencimentoAsync();
                foreach (var produto in produtos)
                {
                    await emailService.SendEmailAsync(produto.Cliente.Email, "Produto Próximo do Vencimento", $"O produto {produto.Nome} está próximo do vencimento.");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
