using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IService
{
    public interface IOrdersService
    {
        Task<int> AddNewOrderAsync(Orders order);
        Task<int> DeleteOrderAsync(int id);
        Task<List<Orders>> GetAllOrdersAsync();
        Task<Orders?> GetOrderByIdAsync(int id);
        Task<List<int>> GetAllIdOrdersAsync();
        Task<int> UpdateOrderAsync(Orders order);
    }
}
