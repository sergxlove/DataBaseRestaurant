using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IHistoryOrdersRepository
    {
        Task<int> Add(HistoryOrders historyOrder);
        Task<int> Delete(int id);
        Task<List<HistoryOrders>> Get();
        Task<HistoryOrders?> GetById(int id);
        Task<int> Update(HistoryOrders historyOrder);
    }
}
