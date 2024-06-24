using PortfolioManagement.Models;
using PortfolioManagement.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioManagement.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _repository.AddAsync(cliente);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            await _repository.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
