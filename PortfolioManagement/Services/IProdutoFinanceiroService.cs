using PortfolioManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagement.Services
{
    public interface IProdutoFinanceiroService
    {
        Task<IEnumerable<ProdutoFinanceiro>> GetAllAsync();
        Task<ProdutoFinanceiro> GetByIdAsync(int id);
        Task AddAsync(ProdutoFinanceiro produto);
        Task UpdateAsync(ProdutoFinanceiro produto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProdutoFinanceiro>> GetProdutosProximosVencimentoAsync();
    }
}
