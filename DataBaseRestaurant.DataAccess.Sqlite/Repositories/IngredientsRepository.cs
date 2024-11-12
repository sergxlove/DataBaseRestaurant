using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Models;
using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRestaurant.DataAccess.Sqlite.Repositories
{
  
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public IngredientsRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Ingredients>> Get()
        {
            var ingredientsEntity = await _dbContext.Ingredients
                .AsNoTracking()
                .ToListAsync();

            return ingredientsEntity.Select(a => Ingredients.Create(a.Id, a.Name, a.Weight, a.QuantityInWareHouse,
                a.SupplierId).ingredients).ToList()!;
        }

        public async Task<Ingredients?> GetById(int id)
        {
            var ingredientEntity = await _dbContext.Ingredients
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (ingredientEntity is not null)
            {
                return Ingredients.Create(ingredientEntity.Id, ingredientEntity.Name, ingredientEntity.Weight,
                    ingredientEntity.QuantityInWareHouse, ingredientEntity.SupplierId).ingredients;
            }
            return null;
        }

        public async Task<int> Add(Ingredients ingredient)
        {
            IngredientsEntity ingredientEntity = new()
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Weight = ingredient.Weight,
                QuantityInWareHouse = ingredient.QuantityInWareHouse,
                SupplierId = ingredient.SupplierId
            };

            await _dbContext.AddAsync(ingredientEntity);
            await _dbContext.SaveChangesAsync();

            return ingredientEntity.Id;
        }

        public async Task<int> Update(Ingredients ingredient)
        {
            return await _dbContext.Ingredients
                .AsNoTracking()
                .Where(a => a.Id == ingredient.Id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(s => s.Id, ingredient.Id)
                .SetProperty(s => s.Name, ingredient.Name)
                .SetProperty(s => s.Weight, ingredient.Weight)
                .SetProperty(s => s.QuantityInWareHouse, ingredient.QuantityInWareHouse)
                .SetProperty(s => s.SupplierId, ingredient.SupplierId));
        }

        public async Task<int> Delete(int id)
        {
            return await _dbContext.Ingredients
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
