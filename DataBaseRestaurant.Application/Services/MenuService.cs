using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Application.Services
{
    public class MenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<List<Menu>> GetAllMenuAsync()
        {
            return await _menuRepository.Get();
        }

        public async Task<Menu?> GetMenuByIdAsync(int id)
        {
            return await _menuRepository.GetById(id);
        }

        public async Task<int> AddNewMenuAsync(Menu menu)
        {
            return await _menuRepository.Add(menu);
        }

        public async Task<int> UpdateMenuAsync(Menu menu)
        {
            return await _menuRepository.Update(menu);
        }

        public async Task<int> DeleteMenuAsync(int id)
        {
            return await _menuRepository.Delete(id);
        }
    }
}
