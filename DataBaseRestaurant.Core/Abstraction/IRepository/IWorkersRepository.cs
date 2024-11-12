using DataBaseRestaurant.Core.Models;

namespace DataBaseRestaurant.Core.Abstraction.IRepository
{
    public interface IWorkersRepository
    {
        Task<int> Add(Workers workers);
        Task<int> Delete(int id);
        Task<List<Workers>> Get();
        Task<Workers?> GetById(int id);
        Task<int> Update(Workers workers);
    }
}
