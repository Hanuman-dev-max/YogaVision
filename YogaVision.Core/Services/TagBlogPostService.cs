

namespace YogaVision.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using YogaVision.Core.Contracts;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class TagBlogPostService : ITagBlogPostService
    {
        private readonly IDeletableEntityRepository<TagBlogPost> tagBlogPostRepository;
        public TagBlogPostService(IDeletableEntityRepository<TagBlogPost> tagBlogPostRepository)
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

        public async Task<List<string>> GetTagByPostId(int postID)
        {
            var tags =
                await this.tagBlogPostRepository
                .All()
                .Where(x => x.BlogPostId == postID)
               .Select(x => x.Tag.Name).ToListAsync();
            return tags;
        }
    }
}
