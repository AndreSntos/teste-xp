using PortfolioManagement.Models;
using PortfolioManagement.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagement.Services
{
    public class InvestimentoService : IInvestimentoService
    {
        private readonly IInvestimentoRepository _repository;

        public InvestimentoService(IInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Investimento>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Investimento> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Investimento investimento)
        {
            await _repository.AddAsync(investimento);
        }

        public async Task UpdateAsync(Investimento investimento)
        {
            await _repository.UpdateAsync(investimento);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Investimento>> GetByClienteIdAsync(int clienteId)
        {
            var investimentos = await _repository.GetAllAsync();
            return investimentos.Where(i => i.ClienteId == clienteId);
        }
    }
}
