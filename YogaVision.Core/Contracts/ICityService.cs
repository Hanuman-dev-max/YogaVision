using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaVision.Core.Contracts
{
    public interface ICityService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task AddAsync(string name);

        Task DeleteAsync(int id);
        Task<T> GetByIdAsync<T>(int id);
    }
}
