namespace YogaVision.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Service for Blog Posts
    /// </summary>
    public interface IBlogPostService
    {
        /// <summary>
        /// Get all blog posts
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        /// <returns></returns>
        
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);
        /// <summary>
        /// Get all similat blog post based on similar tags
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tags">List of tags</param>
        /// <param name="blogId">BlogId which will not be included in the result</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSimilarByTagAsync<T>(List<string> tags, int blogId);
        /// <summary>
        /// Get all blog posts
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sortId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
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
