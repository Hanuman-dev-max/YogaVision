using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaVision.Core.Contracts
{
    public interface IStudioService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllWithSortingFilteringAndPagingAsync<T>(
            string searchString,
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> GetCountForPaginationAsync(string searchString, int? sortId);

        Task<T> GetByIdAsync<T>(string id);

        Task<string> AddAsync(string name, int cityId, string address, string imageUrl);

        Task DeleteAsync(string id);

        
    }
}
