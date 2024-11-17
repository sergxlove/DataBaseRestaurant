using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface ITablesRepository
    {
        Task<int> AddAsync(Tables table);
        Task<int> DeleteAsync(int id);
        Task<List<Tables>> GetAsync();
        Task<Tables?> GetByIdAsync(int id);
        Task<int> UpdateAsync(Tables table);
    }
}
