using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IService
{
    public interface IClientsService
    {
        Task<int> AddNewClientAsync(Clients clients);
        Task<int> DeleteClientAsync(int id);
        Task<List<Clients>> GetAllClientsAsync();
        Task<Clients?> GetClientsByIdAsync(int id);
        Task<List<int>> GetAllIdClientsAsync();
        Task<int> UpdateClientAsync(Clients clients);
    }
}
