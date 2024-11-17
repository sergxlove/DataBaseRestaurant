using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Models;
using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRestaurant.DataAccess.Sqlite.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public OrdersRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Orders>> GetAsync()
        {
            var ordersEntity = await _dbContext.Orders
                .AsNoTracking()
                .ToListAsync();

            return ordersEntity.Select(a => Orders.Create(a.Id, a.TotalSum, a.ClientId, a.TableId).order)
                .ToList()!;
        }

        public async Task<Orders?> GetByIdAsync(int id)
        {
            var orderEntity = await _dbContext.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (orderEntity is not null)
            {
                return Orders.Create(orderEntity.Id, orderEntity.TotalSum, orderEntity.ClientId, orderEntity.TableId)
                    .order;
            }
            return null;
        }

        public async Task<int> AddAsync(Orders order)
        {
            OrdersEntity ordersEntity = new()
            {
                Id = order.Id,
                TotalSum = order.TotalSum,
                ClientId = order.ClientId,
                TableId = order.TableId
            };

            await _dbContext.AddAsync(ordersEntity);
            await _dbContext.SaveChangesAsync();
            return ordersEntity.Id;
        }

        public async Task<int> UpdateAsync(Orders order)
        {
            return await _dbContext.Orders
                .AsNoTracking()
                .Where(a => a.Id == order.Id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(s => s.Id, order.Id)
                .SetProperty(s => s.TotalSum, order.TotalSum)
                .SetProperty(s => s.ClientId, order.ClientId)
                .SetProperty(s => s.TableId, order.TableId));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _dbContext.Orders
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
