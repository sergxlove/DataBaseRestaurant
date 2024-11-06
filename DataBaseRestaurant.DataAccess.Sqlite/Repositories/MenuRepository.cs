using DataBaseRestaurant.Core.Models;
using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataBaseRestaurant.DataAccess.Sqlite.Repositories
{
    public class MenuRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public MenuRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Menu>> Get()
        {
            var menuEntity = await _dbContext.Menu
                .AsNoTracking()
                .ToListAsync();

            return menuEntity.Select(a => Menu.Create(a.Id, a.Name, a.QuantityCalorie, a.Description, a.Price).menu)
                .ToList()!;
        }

        public async Task<Menu?> GetById(int id)
        {
            var menuEntity = await _dbContext.Menu
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if(menuEntity is not null)
            {
                return Menu.Create(menuEntity.Id, menuEntity.Name, menuEntity.QuantityCalorie,
                    menuEntity.Description, menuEntity.Price).menu;
            }
            return null;
        }

        public async Task<int> Add(Menu menu)
        {
            MenuEntity menuEntity = new()
            {
                Id = menu.Id,
                Name = menu.Name,
                QuantityCalorie = menu.QuantityCalorie,
                Description = menu.Description,
                Price = menu.Price
            };

            await _dbContext.AddAsync(menuEntity);
            await _dbContext.SaveChangesAsync();
            return menuEntity.Id;
        }

        public async Task<int> Update(Menu menu)
        {
            return await _dbContext.Menu
                .AsNoTracking()
                .Where(a => a.Id == menu.Id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(s => s.Id, menu.Id)
                .SetProperty(s => s.Name, menu.Name)
                .SetProperty(s => s.QuantityCalorie, menu.QuantityCalorie)
                .SetProperty(s => s.Description, menu.Description)
                .SetProperty(s => s.Price, menu.Price));
        }

        public async Task<int> Delete(int id)
        {
            return await _dbContext.Menu
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }

    }
}
