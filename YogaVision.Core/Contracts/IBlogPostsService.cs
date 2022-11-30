

namespace YogaVision.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IBlogPostsService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);
        Task<IEnumerable<T>> GetSimilarByTagAsync<T>(List<string> tags, int blogId);

        Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> GetCountForPaginationAsync();

        Task<T> GetByIdAsync<T>(int id);

        Task<int> AddAsync(string title,string ShortContent, string content, string author, string imageUrl);

        Task DeleteAsync(int id);
    }
}
