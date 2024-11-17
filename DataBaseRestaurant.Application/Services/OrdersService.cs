using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Application.Services
{
    public class OrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<List<Orders>> GetAllOrdersAsync()
        {
            return await _ordersRepository.GetAsync();
        }

        public async Task<Orders?> GetOrderByIdAsync(int id)
        {
            return await _ordersRepository.GetByIdAsync(id);
        }

        public async Task<int> AddNewOrderAsync(Orders order)
        {
            return await _ordersRepository.AddAsync(order);
        }

        public async Task<int> UpdateOrderAsync(Orders order)
        {
            return await _ordersRepository.UpdateAsync(order);
        }

        public async Task<int> DeleteOrderAsync(int id)
        {
            return await _ordersRepository.DeleteAsync(id);
        }
    }
}
