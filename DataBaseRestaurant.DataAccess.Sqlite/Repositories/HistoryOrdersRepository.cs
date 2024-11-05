using DataBaseRestaurant.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRestaurant.DataAccess.Sqlite.Repositories
{
    public class HistoryOrdersRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public HistoryOrdersRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HistoryOrders>> Get()
        {
            var historyOrders = await _dbContext.HistoryOrders
                .AsNoTracking()
                .ToListAsync();

            return historyOrders.Select(a => HistoryOrders.Create(a.Id, a.ListDishes, a.TotalSum, a.DateOrder,
                a.ClientId).historyorder).ToList()!;
        }

        public async Task<HistoryOrders?> GetById(int id)
        {
            var historyOrder = await _dbContext.HistoryOrders
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if(historyOrder is not null)
            {
                return HistoryOrders.Create(historyOrder.Id, historyOrder.ListDishes, historyOrder.TotalSum,
                    historyOrder.DateOrder, historyOrder.ClientId).historyorder;
            }
            return null;
        }


    }
}
