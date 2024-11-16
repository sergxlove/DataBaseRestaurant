using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Application.Services
{
    public class IngredientsService
    {
        private readonly IIngredientsRepository _ingredientsRepository;

        public IngredientsService(IIngredientsRepository ingredientsRepository)
        {
            _ingredientsRepository = ingredientsRepository;
        }

        public async Task<List<Ingredients>> GetAllIngredients()
        {
            return await _ingredientsRepository.Get();
        }

        public async Task<Ingredients?> GetIngredientsById(int id)
        {
            return await _ingredientsRepository.GetById(id);
        }

        public async Task<int> AddNewIngredients(Ingredients ingredients)
        {
            return await _ingredientsRepository.Add(ingredients);
        }

        public async Task<int> UpdateIngredients(Ingredients ingredients)
        {
            return await _ingredientsRepository.Update(ingredients);
        }

        public async Task<int> DeleteIngredients(int id)
        {
            return await _ingredientsRepository.Delete(id);
        }
    }
}
