using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IClientsRepository
    {
        Task<int> Add(Clients clients);
        Task<int> Delete(int id);
        Task<List<Clients>> Get();
        Task<Clients?> GetById(int id);
        Task<int> Update(Clients clients);
    }
}
