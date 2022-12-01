namespace YogaVision.Core.Contracts
{
    public interface ITagBlogPostService
    {
        Task AddAsync(int blogPostId, List<int> tagsId);
        Task<List<string>> GetTagByPostId(int postID);
    }
}
