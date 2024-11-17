using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IOrdersRepository
    {
        Task<int> AddAsync(Orders order);
        Task<int> DeleteAsync(int id);
        Task<List<Orders>> GetAsync();
        Task<Orders?> GetByIdAsync(int id);
        Task<int> UpdateAsync(Orders order);
    }
}
