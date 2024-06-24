using PortfolioManagement.Data;
using PortfolioManagement.Models;

namespace PortfolioManagement.Repositories
{
    public class InvestimentoRepository : Repository<Investimento>, IInvestimentoRepository
    {
        public InvestimentoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
