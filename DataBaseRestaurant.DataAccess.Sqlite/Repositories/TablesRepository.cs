using DataBaseRestaurant.Core.Models;
using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRestaurant.DataAccess.Sqlite.Repositories
{
    public class TablesRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public TablesRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Tables>> Get()
        {
            var tablesEntity = await _dbContext.Tables
                .AsNoTracking()
                .ToListAsync();

            return tablesEntity.Select(a => Tables.Create(a.Id, a.Status, a.QuantitySeat, a.WorkerId).table).ToList()!;
        }

        public async Task<Tables?> GetById(int id)
        {
            var tableEntity = await _dbContext.Tables
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if(tableEntity is not null)
            {
                return Tables.Create(tableEntity.Id, tableEntity.Status, tableEntity.QuantitySeat, 
                    tableEntity.WorkerId).table;
            }
            return null;
        }

        public async Task<int> Add(Tables table)
        {
            TablesEntity tablesEntity = new()
            {
                Id = table.Id,
                Status = table.Status,
                QuantitySeat = table.QuantitySeat,
                WorkerId = table.WorkerId
            };

            await _dbContext.AddAsync(tablesEntity);
            await _dbContext.SaveChangesAsync();
            return tablesEntity.Id;
        }

        public async Task<int> Update(Tables table)
        {
            return await _dbContext.Tables
                .AsNoTracking()
                .Where(a => a.Id == table.Id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(s => s.Id, table.Id)
                .SetProperty(s => s.Status, table.Status)
                .SetProperty(s => s.QuantitySeat, table.QuantitySeat)
                .SetProperty(s => s.WorkerId, table.WorkerId));
        }

        public async Task<int> Delete(int id)
        {
            return await _dbContext.Tables
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
