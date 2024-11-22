using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Abstraction.IService;
using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Application.Services
{
    public class WorkersService : IWorkersService
    {
        private readonly IWorkersRepository _workersRepository;

        public WorkersService(IWorkersRepository workersRepository)
        {
            _workersRepository = workersRepository;
        }

        public async Task<List<Workers>> GetAllWorkersAsync()
        {
            return await _workersRepository.GetAsync();
        }

        public async Task<Workers?> GetWorkerByIdAsync(int id)
        {
            return await _workersRepository.GetByIdAsync(id);
        }

        public async Task<List<int>> GetAllIdWorkersAsync()
        {
            return await _workersRepository.GetAllIdAsync();
        }

        public async Task<int> AddNewWorkerAsync(Workers worker)
        {
            return await _workersRepository.AddAsync(worker);
        }

        public async Task<int> UpdateWorkerAsync(Workers worker)
        {
            return await _workersRepository.UpdateAsync(worker);
        }

        public async Task<int> DeleteWorkerAsync(int id)
        {
            return await _workersRepository.DeleteAsync(id);
        }
    }
}
