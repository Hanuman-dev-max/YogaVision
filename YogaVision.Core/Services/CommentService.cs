
using Microsoft.EntityFrameworkCore;
using YogaVision.Core.Contracts;
using YogaVision.Infrastructure.Data.Common;
using YogaVision.Infrastructure.Data.Common.Mapping;
using YogaVision.Infrastructure.Data.Models;

namespace YogaVision.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }
        public async  Task AddAsync(string content, int blogId, string userId)
        {
            await this.commentsRepository.AddAsync(new Comment
            {
                  
                ApplicationUserId = userId,
                  BlogPostId = blogId,
                   Content = content
             
            });
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllByBlogPostAsync<T>(int blogPostID)
        {
            var comments =
               await this.commentsRepository
               .All()
               .Where(x => x.BlogPostId == blogPostID)
               .OrderByDescending(x => x.CreatedOn)
               .To<T>().ToListAsync();
            return comments;
        }
    }
}
