using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface ISuppliersRepository
    {
        Task<int> AddAsync(Suppliers supplier);
        Task<int> DeleteAsync(int id);
        Task<List<Suppliers>> GetAsync();
        Task<Suppliers?> GetByIdAsync(int id);
        Task<List<int>> GetAllIdAsync();
        Task<int> UpdateAsync(Suppliers suppliers);
    }
}
