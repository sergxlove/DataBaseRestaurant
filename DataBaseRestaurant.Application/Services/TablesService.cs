using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Abstraction.IService;
using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Application.Services
{
    public class TablesService : ITablesService
    {
        private readonly ITablesRepository _tablesRepository;

        public TablesService(ITablesRepository tablesRepository)
        {
            _tablesRepository = tablesRepository;
        }

        public async Task<List<Tables>> GetAllTablesAsync()
        {
            return await _tablesRepository.GetAsync();
        }

        public async Task<Tables?> GetTableByIdAsync(int id)
        {
            return await _tablesRepository.GetByIdAsync(id);
        }

        public async Task<int> AddNewTAble(Tables table)
        {
            return await _tablesRepository.AddAsync(table);
        }

        public async Task<int> UpdateTableAsync(Tables table)
        {
            return await _tablesRepository.UpdateAsync(table);
        }

        public async Task<int> DeleteTableAsync(int id)
        {
            return await _tablesRepository.DeleteAsync(id);
        }
    }
}
