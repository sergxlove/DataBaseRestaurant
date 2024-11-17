using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Application.Services
{
    public class ClientsService
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientsService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<List<Clients>> GetAllClientsAsync()
        {
            return await _clientsRepository.GetAsync();
        }

        public async Task<Clients?> GetClientsByIdAsync(int id)
        {
            return await _clientsRepository.GetByIdAsync(id);
        }

        public async Task<int> AddNewClientAsync(Clients clients)
        {
            return await _clientsRepository.AddAsync(clients);
        }

        public async Task<int> UpdateClientAsync(Clients clients)
        {
            return await _clientsRepository.UpdateAsync(clients);
        }

        public async Task<int> DeleteClientAsync(int id)
        {
            return await _clientsRepository.DeleteAsync(id);
        }
    }
}
