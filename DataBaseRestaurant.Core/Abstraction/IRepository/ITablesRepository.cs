using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface ITablesRepository
    {
        Task<int> Add(Tables table);
        Task<int> Delete(int id);
        Task<List<Tables>> Get();
        Task<Tables?> GetById(int id);
        Task<int> Update(Tables table);
    }
}
