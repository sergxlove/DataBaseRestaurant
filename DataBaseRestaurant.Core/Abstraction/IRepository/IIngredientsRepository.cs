using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IIngredientsRepository
    {
        Task<int> AddAsync(Ingredients ingredient);
        Task<int> DeleteAsync(int id);
        Task<List<Ingredients>> GetAsync();
        Task<Ingredients?> GetByIdAsync(int id);
        Task<List<int>> GetAllIdAsync();
        Task<int> UpdateAsync(Ingredients ingredient);
    }
}
