namespace YogaVision.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using YogaVision.Core.Contracts;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    /// <summary>
    /// Interface Service for Blog Posts
    /// </summary>
    public class BlogPostService : IBlogPostService
    {
        private readonly IDeletableEntityRepository<BlogPost> blogPostsRepository;
        public BlogPostService(IDeletableEntityRepository<BlogPost> blogPostsRepository)
        {
            this.blogPostsRepository = blogPostsRepository;
        }

        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count">The count of the blog post to be taken</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets all blog posts with paging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sortId">The Id of blog post</param>
        /// <param name="pageSize">The size of the page</param>
        /// <param name="pageIndex">The index of the page</param>
        /// <returns></returns>
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
        /// <summary>
        /// Gets the count of all blog posts
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetCountForPaginationAsync()
        {
            return await this.blogPostsRepository
                .AllAsNoTracking()
                .CountAsync();
        }
        /// <summary>
        /// Gets blog post by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The id of the blog post</param>
        /// <returns>Object of type T</returns>
        public async Task<T> GetByIdAsync<T>(int id)
        {
            var blogPost =
                await this.blogPostsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return blogPost;
        }
        /// <summary>
        /// Adds blog post in the database
        /// </summary>
        /// <param name="title">The title of the blog post</param>
        /// <param name="s0hortContent">The Short content of the blog post</param>
        /// <param name="content">The Content of the blog post</param>
        /// <param name="author">The author of the blog post</param>
        /// <param name="imageUrl">The ImageUrl of the blog post</param>
        /// <returns>The Id of the blog post</returns>
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
        /// <summary>
        /// Deletes blog post by Id
        /// </summary>
        /// <param name="id">The Id of the blog post</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets all similat blog post based on similar tags
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tags">List of tags</param>
        /// <param name="blogId">BlogId which will not be included in the result</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetSimilarByTagAsync<T>(ICollection<string> tags , int blogId)
        {
            var blogPosts =
                await this.blogPostsRepository
                .All()
                .Where(x => x.Tags.Any(t => tags.Contains(t.Tag.Name)) && x.Id!=blogId)
                .OrderByDescending(x => x.CreatedOn)
                .To<T>().ToListAsync();
            return blogPosts;
        }
        /// <summary>
        /// Add user's like to the BlogPost
        /// </summary>
        /// <param name="id">BlogPost Id</param>
        /// <param name="userId">User Id</param>
        /// <returns></returns>
        public async  Task AddLikeAsync(int id, string userId)
        {
            var blogPost =
               await this.blogPostsRepository
               .All()
               .Where(x => x.Id == id)
              .FirstOrDefaultAsync();
            blogPost.Likes++;
            await this.blogPostsRepository.SaveChangesAsync();
        }
    }
}