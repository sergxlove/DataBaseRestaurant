using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IMenuRepository
    {
        Task<int> AddAsync(Menu menu);
        Task<int> DeleteAsync(int id);
        Task<List<Menu>> GetAsync();
        Task<Menu?> GetByIdAsync(int id);
        Task<List<int>> GetAllIdAsync();
        Task<int> UpdateAsync(Menu menu);
    }
}
