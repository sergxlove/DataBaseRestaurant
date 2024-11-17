using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Models;
using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRestaurant.DataAccess.Sqlite.Repositories
{
    public class HistoryOrdersRepository : IHistoryOrdersRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public HistoryOrdersRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HistoryOrders>> GetAsync()
        {
            var historyOrders = await _dbContext.HistoryOrders
                .AsNoTracking()
                .ToListAsync();

            return historyOrders.Select(a => HistoryOrders.Create(a.Id, a.ListDishes, a.TotalSum, a.DateOrder,
                a.ClientId).historyorder).ToList()!;
        }

        public async Task<HistoryOrders?> GetByIdAsync(int id)
        {
            var historyOrder = await _dbContext.HistoryOrders
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (historyOrder is not null)
            {
                return HistoryOrders.Create(historyOrder.Id, historyOrder.ListDishes, historyOrder.TotalSum,
                    historyOrder.DateOrder, historyOrder.ClientId).historyorder;
            }
            return null;
        }

        public async Task<int> AddAsync(HistoryOrders historyOrder)
        {
            HistoryOrdersEntity historyOrdersEntity = new()
            {
                Id = historyOrder.Id,
                ListDishes = historyOrder.ListDishes,
                TotalSum = historyOrder.TotalSum,
                DateOrder = historyOrder.DateOrder,
                ClientId = historyOrder.ClientId
            };

            await _dbContext.AddAsync(historyOrdersEntity);
            await _dbContext.SaveChangesAsync();

            return historyOrder.Id;
        }

        public async Task<int> UpdateAsync(HistoryOrders historyOrder)
        {
            return await _dbContext.HistoryOrders
                .AsNoTracking()
                .Where(a => a.Id == historyOrder.Id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(s => s.Id, historyOrder.Id)
                .SetProperty(s => s.ListDishes, historyOrder.ListDishes)
                .SetProperty(s => s.TotalSum, historyOrder.TotalSum)
                .SetProperty(s => s.DateOrder, historyOrder.DateOrder)
                .SetProperty(s => s.ClientId, historyOrder.ClientId));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _dbContext.HistoryOrders
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
