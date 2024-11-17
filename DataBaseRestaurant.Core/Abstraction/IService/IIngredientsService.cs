using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IService
{
    public interface IIngredientsService
    {
        Task<int> AddNewIngredientsAsync(Ingredients ingredients);
        Task<int> DeleteIngredientsAsync(int id);
        Task<List<Ingredients>> GetAllIngredientsAsync();
        Task<Ingredients?> GetIngredientsByIdAsync(int id);
        Task<int> UpdateIngredientsAsync(Ingredients ingredients);
    }
}
