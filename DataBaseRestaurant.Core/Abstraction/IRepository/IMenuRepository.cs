using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IMenuRepository
    {
        Task<int> Add(Menu menu);
        Task<int> Delete(int id);
        Task<List<Menu>> Get();
        Task<Menu?> GetById(int id);
        Task<int> Update(Menu menu);
    }
}
