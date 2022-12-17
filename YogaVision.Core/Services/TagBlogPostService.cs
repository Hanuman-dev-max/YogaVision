namespace YogaVision.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using YogaVision.Core.Contracts;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Models;
    /// <summary>
    /// Service for TagBlogPost 
    /// </summary>
    public class TagBlogPostService : ITagBlogPostService
    {
        private readonly IDeletableEntityRepository<TagBlogPost> tagBlogPostRepository;
        public TagBlogPostService(IDeletableEntityRepository<TagBlogPost> tagBlogPostRepository)
        {
            this.tagBlogPostRepository = tagBlogPostRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blogPostId"></param>
        /// <param name="tagIds"></param>
        /// <returns></returns>
        public async Task AddAsync(int blogPostId, ICollection<int> tagIds)
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

        public async Task ClearBlogTags(int blogId)
        {
            var tagsBlogPosts =
                await this.tagBlogPostRepository
                .All()
                .Where(tb => tb.BlogPostId == blogId)
                .ToListAsync();
            foreach (var tagBlogPost in tagsBlogPosts)
            {
                tagBlogPost.IsDeleted = true;
            }
            await this.tagBlogPostRepository.SaveChangesAsync();
        }

        public async Task<ICollection<string>> GetTagByPostId(int postId)
        {
            var tags =
                await this.tagBlogPostRepository
                .All()
                .Where(x => x.BlogPostId == postId)
               .Select(x => x.Tag.Name).ToListAsync();
            return tags;
        }
    }
}
