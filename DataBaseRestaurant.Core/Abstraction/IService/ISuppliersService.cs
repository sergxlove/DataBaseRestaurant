using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IService
{
    public interface ISuppliersService
    {
        Task<int> AddNewSupplierAsync(Suppliers supplier);
        Task<int> DeleteSupplierAsync(int id);
        Task<List<Suppliers>> GetAllSuppliersAsync();
        Task<Suppliers?> GetSupplierByIdAsync(int id);
        Task<int> UpdateSupplierAsync(Suppliers supplier);
    }
}
