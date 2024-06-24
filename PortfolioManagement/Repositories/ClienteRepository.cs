using PortfolioManagement.Data;
using PortfolioManagement.Models;

namespace PortfolioManagement.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
