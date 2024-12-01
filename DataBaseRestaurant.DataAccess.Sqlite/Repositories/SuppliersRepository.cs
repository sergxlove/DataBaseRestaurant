using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Models;
using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRestaurant.DataAccess.Sqlite.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public SuppliersRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Suppliers>> GetAsync()
        {
            var suppliersEntity = await _dbContext.Suppliers
                .AsNoTracking()
                .ToListAsync();

            return suppliersEntity.Select(a => Suppliers.Create(a.Id, a.Name, a.Email, a.NumberPhone, a.Ratting).supplier).ToList()!;
        }

        public async Task<Suppliers?> GetByIdAsync(int id)
        {
            var suppliersEntity = await _dbContext.Suppliers
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (suppliersEntity is not null)
            {
                return Suppliers.Create(suppliersEntity.Id, suppliersEntity.Name, suppliersEntity.Email,
                    suppliersEntity.NumberPhone, suppliersEntity.Ratting).supplier;
            }
            return null;
        }

        public async Task<List<int>> GetAllIdAsync()
        {
            return await _dbContext.Suppliers
                .AsNoTracking()
                .Select(a => a.Id)
                .ToListAsync();
        }

        public async Task<int> AddAsync(Suppliers supplier)
        {
            SuppliersEntity suppliersEntity = new()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Email = supplier.Email,
                NumberPhone = supplier.NumberPhone,
                Ratting = supplier.Ratting
            };

            await _dbContext.AddAsync(suppliersEntity);
            await _dbContext.SaveChangesAsync();
            return suppliersEntity.Id;
        }

        public async Task<int> UpdateAsync(Suppliers suppliers)
        {
            return await _dbContext.Suppliers
                .AsNoTracking()
                .Where(a => a.Id == suppliers.Id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(s => s.Name, suppliers.Name)
                .SetProperty(s => s.Email, suppliers.Email)
                .SetProperty(s => s.NumberPhone, suppliers.NumberPhone)
                .SetProperty(s => s.Ratting, suppliers.Ratting));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _dbContext.Suppliers
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
