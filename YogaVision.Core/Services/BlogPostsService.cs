namespace YogaVision.Core.Services
{
    using Microsoft.EntityFrameworkCore;

    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.Tags;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class BlogPostsService : IBlogPostsService
    {
        private readonly IDeletableEntityRepository<BlogPost> blogPostsRepository;


        public BlogPostsService(IDeletableEntityRepository<BlogPost> blogPostsRepository, ITagService tagService)
        {
            this.blogPostsRepository = blogPostsRepository;

        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int? count = null)
        {
            IQueryable<BlogPost> query =
                this.blogPostsRepository
                .All()
                .OrderByDescending(x => x.CreatedOn);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }
            return await query.To<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex)
        {
            IQueryable<BlogPost> query =
                this.blogPostsRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn);

            if (sortId != null)
            {
                query = query
                    .Where(x => x.Id == sortId);
            }

            return await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).To<T>().ToListAsync();
        }

        public async Task<int> GetCountForPaginationAsync()
        {
            return await this.blogPostsRepository
                .AllAsNoTracking()
                .CountAsync();

            // return await query.CountAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var blogPost =
                await this.blogPostsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return blogPost;
        }

        public async Task<int> AddAsync(string title, string shortContent, string content, string author, string imageUrl)
        {
           
            var blogPost = new BlogPost()
            {
                Title = title,
                ShortContent = shortContent,
                Content = content,
                Author = author,
                ImageUrl = imageUrl,
            };

            await this.blogPostsRepository.AddAsync(blogPost);
            await this.blogPostsRepository.SaveChangesAsync();
            return blogPost.Id;

        }

        public async Task DeleteAsync(int id)
        {
            var blogPost =
                await this.blogPostsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.blogPostsRepository.Delete(blogPost);
            await this.blogPostsRepository.SaveChangesAsync();
        }
    }
}
