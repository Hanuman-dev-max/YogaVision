namespace YogaVision.Core.Contracts
{
    public interface ITagBlogPostsService
    {
        Task AddAsync(int blogPostId, List<int> tagsId);
        Task<List<string>> GetTagByPostId(int postID);
    }
}
