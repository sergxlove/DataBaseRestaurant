using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Models;
using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRestaurant.DataAccess.Sqlite.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public ClientsRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Clients>> GetAsync()
        {
            var clientsEntity = await _dbContext.Clients
                .AsNoTracking()
                .ToListAsync();

            return clientsEntity.Select(a => Clients.Create(a.Id, a.Name, a.Email, a.Preferences, a.OrderId).client)
                .ToList()!;
        }

        public async Task<Clients?> GetByIdAsync(int id)
        {
            var client = await _dbContext.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (client is not null)
            {
                return Clients.Create(client.Id, client.Name, client.Email, client.Preferences, client.OrderId).client;
            }
            return null;
        }

        public async Task<List<int>> GetAllIdAsync()
        {
            return await _dbContext.Clients.AsNoTracking()
                .Select(a => a.Id)
                .ToListAsync();
        }

        public async Task<int> AddAsync(Clients clients)
        {
            ClientsEntity clientsEntity = new()
            {
                Id = clients.Id,
                Name = clients.Name,
                Email = clients.Email,
                Preferences = clients.Preferences,
                OrderId = clients.OrderId
            };

            await _dbContext.AddAsync(clientsEntity);
            await _dbContext.SaveChangesAsync();

            return clientsEntity.Id;
        }

        public async Task<int> UpdateAsync(Clients clients)
        {
            return await _dbContext.Clients
                .AsNoTracking()
                .Where(a => a.Id == clients.Id)
                .ExecuteUpdateAsync(s =>
                s.SetProperty(s => s.Id, clients.Id)
                .SetProperty(s => s.Name, clients.Name)
                .SetProperty(s => s.Email, clients.Email)
                .SetProperty(s => s.Preferences, clients.Preferences)
                .SetProperty(s => s.OrderId, clients.OrderId));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _dbContext.Clients
                .AsNoTracking()
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
