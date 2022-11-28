

namespace YogaVision.Core.Services
{
    using YogaVision.Core.Contracts;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Models;
    public class TagBlogPostsService : ITagBlogPostsService
    {
        private readonly IDeletableEntityRepository<TagBlogPost> tagBlogPostRepository;
        public TagBlogPostsService(IDeletableEntityRepository<TagBlogPost> tagBlogPostRepository)
        {
            this.tagBlogPostRepository = tagBlogPostRepository;
        }

        public async Task AddAsync(int blogPostId, List<int> tagIds)
        {

            foreach (var tagId in tagIds)
            {
                var tagBlogPost = new TagBlogPost
                {
                    TagId = tagId,
                    BlogPostId = blogPostId,
                };

                await this.tagBlogPostRepository.AddAsync(tagBlogPost);
            }
            await this.tagBlogPostRepository.SaveChangesAsync();
        }
    }
}
