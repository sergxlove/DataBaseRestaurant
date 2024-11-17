using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IHistoryOrdersRepository
    {
        Task<int> AddAsync(HistoryOrders historyOrder);
        Task<int> DeleteAsync(int id);
        Task<List<HistoryOrders>> GetAsync();
        Task<HistoryOrders?> GetByIdAsync(int id);
        Task<int> UpdateAsync(HistoryOrders historyOrder);
    }
}
