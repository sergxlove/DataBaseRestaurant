using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Abstraction.IService;
using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Application.Services
{
    public class HistoryOrdersService : IHistoryOrdersService
    {
        private readonly IHistoryOrdersRepository _historyOrdersRepository;

        public HistoryOrdersService(IHistoryOrdersRepository historyOrdersRepository)
        {
            _historyOrdersRepository = historyOrdersRepository;
        }

        public async Task<List<HistoryOrders>> GetAllHistoryOrdersAsync()
        {
            return await _historyOrdersRepository.GetAsync();
        }

        public async Task<HistoryOrders?> GetHistoryOrderByIdAsync(int id)
        {
            return await _historyOrdersRepository.GetByIdAsync(id);
        }

        public async Task<int> AddNewHistoryOrderAsync(HistoryOrders historyOrders)
        {
            return await _historyOrdersRepository.AddAsync(historyOrders);
        }

        public async Task<int> UpdateHistoryOrderAsync(HistoryOrders historyOrders)
        {
            return await _historyOrdersRepository.UpdateAsync(historyOrders);
        }

        public async Task<int> DeleteHistoryOrderAsync(int id)
        {
            return await _historyOrdersRepository.DeleteAsync(id);
        }
    }
}
