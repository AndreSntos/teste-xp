using PortfolioManagement.Models;
using PortfolioManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioManagement.Services
{
    public class ProdutoFinanceiroService : IProdutoFinanceiroService
    {
        private readonly IProdutoFinanceiroRepository _repository;

        public ProdutoFinanceiroService(IProdutoFinanceiroRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProdutoFinanceiro>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProdutoFinanceiro> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(ProdutoFinanceiro produto)
        {
            await _repository.AddAsync(produto);
        }

        public async Task UpdateAsync(ProdutoFinanceiro produto)
        {
            await _repository.UpdateAsync(produto);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProdutoFinanceiro>> GetProdutosProximosVencimentoAsync()
        {
            var produtos = await _repository.GetAllAsync();
            return produtos.Where(p => p.DataDeVencimento <= DateTime.Now.AddDays(7));
        }
    }
}
