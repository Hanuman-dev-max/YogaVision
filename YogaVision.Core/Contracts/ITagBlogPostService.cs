namespace YogaVision.Core.Contracts
{
    /// <summary>
    /// Inteface for TagBlogPost Service
    /// </summary>
    public interface ITagBlogPostService
    {
        /// <summary>
        /// Adds TagBlogPosts in the database
        /// </summary>
        /// <param name="blogPostId">The Id of the blogPost</param>
        /// <param name="tagsId">The Ids of the tags</param>
        /// <returns></returns>
        Task AddAsync(int blogPostId, ICollection<int> tagsId);
        /// <summary>
        /// Gets the tags of BlogPost
        /// </summary>
        /// <param name="postId">The Id of BlogPost</param>
        /// <returns>Collection of string - the names of tags</returns>
        Task<ICollection<string>> GetTagByPostId(int postId);
    }
}
