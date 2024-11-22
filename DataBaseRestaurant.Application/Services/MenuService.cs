using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Abstraction.IService;
using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<List<Menu>> GetAllMenuAsync()
        {
            return await _menuRepository.GetAsync();
        }

        public async Task<Menu?> GetMenuByIdAsync(int id)
        {
            return await _menuRepository.GetByIdAsync(id);
        }

        public async Task<List<int>> GetAllIdMenuAsync()
        {
            return await _menuRepository.GetAllIdAsync();
        }

        public async Task<int> AddNewMenuAsync(Menu menu)
        {
            return await _menuRepository.AddAsync(menu);
        }

        public async Task<int> UpdateMenuAsync(Menu menu)
        {
            return await _menuRepository.UpdateAsync(menu);
        }

        public async Task<int> DeleteMenuAsync(int id)
        {
            return await _menuRepository.DeleteAsync(id);
        }
    }
}
