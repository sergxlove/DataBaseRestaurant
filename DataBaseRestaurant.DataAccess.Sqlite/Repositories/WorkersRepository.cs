using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Models;
using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRestaurant.DataAccess.Sqlite.Repositories
{
    public class WorkersRepository : IWorkersRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public WorkersRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Workers>> GetAsync()
        {
            var workersEntity = await _dbContext.Workers
                .AsNoTracking()
                .ToListAsync();
            return workersEntity.Select(a => Workers.Create(a.Id, a.Name, a.Email, a.NumberPhone, a.Position, a.Salary)
                .worker).ToList()!;
        }

        public async Task<Workers?> GetByIdAsync(int id)
        {
            var workerEntity = await _dbContext.Workers
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
            if (workerEntity is not null)
            {
                return Workers.Create(workerEntity.Id, workerEntity.Name, workerEntity.Email, workerEntity.NumberPhone,
                    workerEntity.Position, workerEntity.Salary).worker;
            }
            return null;
        }

        public async Task<int> AddAsync(Workers workers)
        {
            WorkersEntity worker = new()
            {
                Id = workers.Id,
                Name = workers.Name,
                Email = workers.Email,
                NumberPhone = workers.NumberPhone,
                Position = workers.Position,
                Salary = workers.Salary
            };

            await _dbContext.Workers.AddAsync(worker);
            await _dbContext.SaveChangesAsync();

            return worker.Id;

        }

        public async Task<int> UpdateAsync(Workers workers)
        {
            return await _dbContext.Workers
                .AsNoTracking()
                .Where(a => a.Id == workers.Id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(s => s.Name, workers.Name)
                .SetProperty(s => s.Email, workers.Email)
                .SetProperty(s => s.NumberPhone, workers.NumberPhone)
                .SetProperty(s => s.Position, workers.Position)
                .SetProperty(s => s.Salary, workers.Salary));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _dbContext.Workers
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
