using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface ISuppliersRepository
    {
        Task<int> Add(Suppliers supplier);
        Task<int> Delete(int id);
        Task<List<Suppliers>> Get();
        Task<Suppliers?> GetById(int id);
        Task<int> Update(Suppliers suppliers);
    }
}
