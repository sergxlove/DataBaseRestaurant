using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IService
{
    public interface ITablesService
    {
        Task<int> AddNewTAble(Tables table);
        Task<int> DeleteTableAsync(int id);
        Task<List<Tables>> GetAllTablesAsync();
        Task<Tables?> GetTableByIdAsync(int id);
        Task<List<int>> GetAllIdTableAsync();
        Task<int> UpdateTableAsync(Tables table);
    }
}
