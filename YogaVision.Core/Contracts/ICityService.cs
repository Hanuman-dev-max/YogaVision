
namespace YogaVision.Core.Contracts
{
  
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICityService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task AddAsync(string name);

        Task DeleteAsync(int id);
        Task<T> GetByIdAsync<T>(int id);
    }
}
