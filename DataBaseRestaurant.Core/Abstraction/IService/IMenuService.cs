using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IService
{
    public interface IMenuService
    {
        Task<int> AddNewMenuAsync(Menu menu);
        Task<int> DeleteMenuAsync(int id);
        Task<List<Menu>> GetAllMenuAsync();
        Task<Menu?> GetMenuByIdAsync(int id);
        Task<List<int>> GetAllIdMenuAsync();
        Task<int> UpdateMenuAsync(Menu menu);
    }
}
