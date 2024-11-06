using DataBaseRestaurant.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRestaurant.DataAccess.Sqlite.Repositories
{
    public class OrdersRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public OrdersRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Orders>> Get()
        {
            var ordersEntity = await _dbContext.Orders
                .AsNoTracking()
                .ToListAsync();

            return ordersEntity.Select(a => Orders.Create(a.Id, a.TotalSum, a.ClientId, a.TableId).order)
                .ToList()!;
        }
    }
}
