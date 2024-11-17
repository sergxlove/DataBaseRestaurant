﻿using DataBaseRestaurant.Core.Abstraction.IRepository;
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

        public async Task<List<Ingredients>> GetAllIngredientsAsync()
        {
            return await _ingredientsRepository.GetAsync();
        }

        public async Task<Ingredients?> GetIngredientsByIdAsync(int id)
        {
            return await _ingredientsRepository.GetByIdAsync(id);
        }

        public async Task<int> AddNewIngredientsAsync(Ingredients ingredients)
        {
            return await _ingredientsRepository.AddAsync(ingredients);
        }

        public async Task<int> UpdateIngredientsAsync(Ingredients ingredients)
        {
            return await _ingredientsRepository.UpdateAsync(ingredients);
        }

        public async Task<int> DeleteIngredientsAsync(int id)
        {
            return await _ingredientsRepository.DeleteAsync(id);
        }
    }
}