namespace YogaVision.Core.Contracts
{
    public interface ICommentService
    {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="Content"></param>
      /// <param name="BlogId"></param>
      /// <param name="UserId"></param>
      /// <returns></returns>
        Task AddAsync(string Content, int BlogId, string UserId);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Collection of type T</returns>
        Task<IEnumerable<T>> GetAllByBlogPostAsync<T>(int blogPostID);
    }
}
