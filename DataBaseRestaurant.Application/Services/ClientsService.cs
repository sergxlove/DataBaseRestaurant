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

        public async Task<List<Clients>> GetAllClients()
        {
            return await _clientsRepository.Get();
        }

        public async Task<Clients?> GetClientsById(int id)
        {
            return await _clientsRepository.GetById(id);
        }

        public async Task<int> AddNewClient(Clients clients)
        {
            return await _clientsRepository.Add(clients);
        }

        public async Task<int> UpdateClient(Clients clients)
        {
            return await _clientsRepository.Update(clients);
        }

        public async Task<int> DeleteClient(int id)
        {
            return await _clientsRepository.Delete(id);
        }
    }
}
