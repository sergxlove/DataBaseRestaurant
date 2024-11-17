using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Abstraction.IService;
using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Application.Services
{
    public class SuppliersService : ISuppliersService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public async Task<List<Suppliers>> GetAllSuppliersAsync()
        {
            return await _suppliersRepository.GetAsync();
        }

        public async Task<Suppliers?> GetSupplierByIdAsync(int id)
        {
            return await _suppliersRepository.GetByIdAsync(id);
        }

        public async Task<int> AddNewSupplierAsync(Suppliers supplier)
        {
            return await _suppliersRepository.AddAsync(supplier);
        }

        public async Task<int> UpdateSupplierAsync(Suppliers supplier)
        {
            return await _suppliersRepository.UpdateAsync(supplier);
        }

        public async Task<int> DeleteSupplierAsync(int id)
        {
            return await _suppliersRepository.DeleteAsync(id);
        }
    }
}
