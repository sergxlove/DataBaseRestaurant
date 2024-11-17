using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IService
{
    public interface IHistoryOrdersService
    {
        Task<int> AddNewHistoryOrderAsync(HistoryOrders historyOrders);
        Task<int> DeleteHistoryOrderAsync(int id);
        Task<List<HistoryOrders>> GetAllHistoryOrdersAsync();
        Task<HistoryOrders?> GetHistoryOrderByIdAsync(int id);
        Task<int> UpdateHistoryOrderAsync(HistoryOrders historyOrders);
    }
}
