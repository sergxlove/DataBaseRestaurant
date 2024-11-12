using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IIngredientsRepository
    {
        Task<int> Add(Ingredients ingredient);
        Task<int> Delete(int id);
        Task<List<Ingredients>> Get();
        Task<Ingredients?> GetById(int id);
        Task<int> Update(Ingredients ingredient);
    }
}
