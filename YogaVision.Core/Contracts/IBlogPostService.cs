namespace YogaVision.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Interface Service for Blog Posts
    /// </summary>
    public interface IBlogPostService
    {
        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count">The count of the blog post to be taken</param>
        /// <returns></returns>

        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);
        /// <summary>
        /// Gets all similat blog post based on similar tags
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tags">List of tags</param>
        /// <param name="blogId">BlogId which will not be included in the result</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetSimilarByTagAsync<T>(ICollection<string> tags, int blogId);
        /// <summary>
        /// Gets all blog posts with paging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sortId">The id of blog post</param>
        /// <param name="pageSize">The size of the page</param>
        /// <param name="pageIndex">The index of the page</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex);
        /// <summary>
        /// Gets the count of all blog posts
        /// </summary>
        /// <returns></returns>
        Task<int> GetCountForPaginationAsync();
        /// <summary>
        /// Gets blog post by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The id of the blog post</param>
        /// <returns>Object of type T</returns>
        Task<T> GetByIdAsync<T>(int id);
        /// <summary>
        /// Adds blog post in the database
        /// </summary>
        /// <param name="title">The title of the blog post</param>
        /// <param name="s0hortContent">The Short content of the blog post</param>
        /// <param name="content">The Content of the blog post</param>
        /// <param name="author">The author of the blog post</param>
        /// <param name="imageUrl">The ImageUrl of the blog post</param>
        /// <returns>The Id of the blog post</returns>
        Task<int> AddAsync(string title,string shortContent, string content, string author, string imageUrl);

        /// <summary>
        /// Deletes blog post by Id
        /// </summary>
        /// <param name="id">The Id of the blog post</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
        /// <summary>
        /// Add user's like to the BlogPost
        /// </summary>
        /// <param name="id">BlogPost Id</param>
        /// <param name="userId">User Id</param>
        /// <returns></returns>
        Task AddLikeAsync(int id, string userId);
       

    }
}