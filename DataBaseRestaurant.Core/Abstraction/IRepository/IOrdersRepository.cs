using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IOrdersRepository
    {
        Task<int> Add(Orders order);
        Task<int> Delete(int id);
        Task<List<Orders>> Get();
        Task<Orders?> GetById(int id);
        Task<int> Update(Orders order);
    }
}
