using PortfolioManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagement.Services
{
    public interface IInvestimentoService
    {
        Task<IEnumerable<Investimento>> GetAllAsync();
        Task<Investimento> GetByIdAsync(int id);
        Task AddAsync(Investimento investimento);
        Task UpdateAsync(Investimento investimento);
        Task DeleteAsync(int id);
        Task<IEnumerable<Investimento>> GetByClienteIdAsync(int clienteId);
    }
}
