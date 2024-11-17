using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IClientsRepository
    {
        Task<int> AddAsync(Clients clients);
        Task<int> DeleteAsync(int id);
        Task<List<Clients>> GetAsync();
        Task<Clients?> GetByIdAsync(int id);
        Task<int> UpdateAsync(Clients clients);
    }
}
