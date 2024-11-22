using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IWorkersRepository
    {
        Task<int> AddAsync(Workers workers);
        Task<int> DeleteAsync(int id);
        Task<List<Workers>> GetAsync();
        Task<Workers?> GetByIdAsync(int id);
        Task<List<int>> GetAllIdAsync();
        Task<int> UpdateAsync(Workers workers);
    }
}
