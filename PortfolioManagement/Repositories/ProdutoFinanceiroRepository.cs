using PortfolioManagement.Data;
using PortfolioManagement.Models;

namespace PortfolioManagement.Repositories
{
    public class ProdutoFinanceiroRepository : Repository<ProdutoFinanceiro>, IProdutoFinanceiroRepository
    {
        public ProdutoFinanceiroRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
