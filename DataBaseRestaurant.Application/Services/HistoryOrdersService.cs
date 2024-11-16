using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Application.Services
{
    public class HistoryOrdersService
    {
        private readonly IHistoryOrdersRepository _historyOrdersRepository;

        public HistoryOrdersService(IHistoryOrdersRepository historyOrdersRepository)
        {
            _historyOrdersRepository = historyOrdersRepository;
        }

        public async Task<List<HistoryOrders>> GetAllHistoryOrders()
        {
            return await _historyOrdersRepository.Get();
        }

        public async Task<HistoryOrders?> GetHistoryOrderById(int id)
        {
            return await _historyOrdersRepository.GetById(id);
        }

        public async Task<int> AddNewHistoryOrder(HistoryOrders historyOrders)
        {
            return await _historyOrdersRepository.Add(historyOrders);
        }

        public async Task<int> UpdateHistoryOrder(HistoryOrders historyOrders)
        {
            return await _historyOrdersRepository.Update(historyOrders);
        }

        public async Task<int> DeleteHistoryOrder(int id)
        {
            return await _historyOrdersRepository.Delete(id);
        }
    }
}
