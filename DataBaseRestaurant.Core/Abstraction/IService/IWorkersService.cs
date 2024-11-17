using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IService
{
    public interface IWorkersService
    {
        Task<int> AddNewWorkerAsync(Workers worker);
        Task<int> DeleteWorkerAsync(int id);
        Task<List<Workers>> GetAllWorkersAsync();
        Task<Workers?> GetWorkerByIdAsync(int id);
        Task<int> UpdateWorkerAsync(Workers worker);
    }
}
