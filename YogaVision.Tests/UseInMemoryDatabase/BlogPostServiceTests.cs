namespace YogaVision.Tests.UseInMemoryDatabase
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;
    using YogaVision.Core.Models.City;
    using YogaVision.Core.Services;
    using YogaVision.Infrastructure.Data.Models;
    public  class BlogPostServiceTests :BaseServiceTests
    {
        private IBlogPostService Service => this.ServiceProvider.GetRequiredService<IBlogPostService>();

        [Fact]
        public async Task GetCountForPaginationAsyncShouldReturnCorrectCount()
        {
            await this.CreateBlogPostAsync();
            await this.CreateBlogPostAsync();
            await this.CreateBlogPostAsync();

            var expected = this.DbContext.BlogPosts.Where(x => !x.IsDeleted).ToArray().Count();
            var actual = await this.Service.GetCountForPaginationAsync();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            await this.CreateBlogPostAsync();

            var title = new NLipsum.Core.Sentence().ToString();
            var shortContent = new NLipsum.Core.Sentence().ToString();
            var content = new NLipsum.Core.Paragraph().ToString();
            var author = new NLipsum.Core.Word().ToString();
            var imageUrl = new NLipsum.Core.Word().ToString();

            await this.Service.AddAsync(title,shortContent, content, author, imageUrl);

            var blogPostsCount = await this.DbContext.BlogPosts.CountAsync();
            Assert.Equal(2, blogPostsCount);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var blogPost = await this.CreateBlogPostAsync();

            await this.Service.DeleteAsync(blogPost.Id);

            var blogPostsCount = this.DbContext.BlogPosts.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedBlogPost = await this.DbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            Assert.Equal(0, blogPostsCount);
            Assert.Null(deletedBlogPost);
        }

        
        [Fact]
        public async Task GetAllAsyncShouldReturnCorrectly()
        {
            await this.CreateBlogPostAsync();
            await this.CreateBlogPostAsync();
            await this.CreateBlogPostAsync();

            var expected = this.DbContext.BlogPosts.Where(x => !x.IsDeleted).ToArray().Count();
            var actual = await this.Service.GetAllAsync<BlogPostViewModel>();
            Assert.Equal(expected, actual.Count());
        }
        [Fact]
        public async Task GetAllWithPagingAsyncShouldReturnCorrectly()
        {
            await this.CreateBlogPostAsync();
            await this.CreateBlogPostAsync();
            await this.CreateBlogPostAsync();
            await this.CreateBlogPostAsync();
            await this.CreateBlogPostAsync();
            await this.CreateBlogPostAsync();

            var actual = await this.Service.GetAllWithPagingAsync<BlogPostViewModel>(null, 3, 1);
            Assert.Equal(3, actual.Count());
        }
        [Fact]
        public async Task GetByIdShouldReturnCorrectly()
        {
            //Arranege
            var blogPost = await this.CreateBlogPostAsync();

            //Act
            var actualBlogPost = await this.Service.GetByIdAsync<BlogPostViewModel>(blogPost.Id);
            //Assert
            Assert.Equal(blogPost.Title, actualBlogPost.Title);
        }

        [Fact]
        public async Task GetSimilarByTagAsyncShouldReturnCorrectly()
        {
            var tag1 = new Tag { Name = "tag1" };
            var tag2 = new Tag { Name = "tag2" };
            var blogPost1 = new BlogPost
            {
                Title = new NLipsum.Core.Word().ToString(),
                Content = new NLipsum.Core.Paragraph().ToString(),
                Author = new NLipsum.Core.Word().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
                ShortContent = new NLipsum.Core.Paragraph().ToString(),
                Tags = new HashSet<TagBlogPost>() {new TagBlogPost(){  Tag = tag1 } }
            };
            var blogPost2 = new BlogPost
            {
                Title = new NLipsum.Core.Word().ToString(),
                Content = new NLipsum.Core.Paragraph().ToString(),
                Author = new NLipsum.Core.Word().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
                ShortContent = new NLipsum.Core.Paragraph().ToString(),
                Tags = new HashSet<TagBlogPost>() { new TagBlogPost() { Tag = tag1 } }
            };
            var blogPost3 = new BlogPost
            {
                Title = new NLipsum.Core.Word().ToString(),
                Content = new NLipsum.Core.Paragraph().ToString(),
                Author = new NLipsum.Core.Word().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
                ShortContent = new NLipsum.Core.Paragraph().ToString(),
                Tags = new HashSet<TagBlogPost>() { new TagBlogPost() { Tag = tag2 } }
            };
            await this.DbContext.BlogPosts.AddAsync(blogPost1);
            await this.DbContext.SaveChangesAsync();
            await this.DbContext.BlogPosts.AddAsync(blogPost2);
            await this.DbContext.SaveChangesAsync();
            await this.DbContext.BlogPosts.AddAsync(blogPost3);
            await this.DbContext.SaveChangesAsync();

            var actualBlogPostWithSimilarTag = await this.Service.GetSimilarByTagAsync<BlogPostViewModel>(new List<string>() { "tag1" }, blogPost1.Id);
            var actualBlogPostWithoutSimilartag = await this.Service.GetSimilarByTagAsync<BlogPostViewModel>(new List<string>() { "tag2" }, blogPost3.Id);
            Assert.Equal(1, actualBlogPostWithSimilarTag.Count());
            Assert.Equal(0, actualBlogPostWithoutSimilartag.Count());
        }





        private async Task<BlogPost> CreateBlogPostAsync()
        {
            var blogPost = new BlogPost
            {
                Title = new NLipsum.Core.Word().ToString(),
                Content = new NLipsum.Core.Paragraph().ToString(),
                Author = new NLipsum.Core.Word().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
                ShortContent = new NLipsum.Core.Paragraph().ToString(),

            };

            await this.DbContext.BlogPosts.AddAsync(blogPost);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<BlogPost>(blogPost).State = EntityState.Detached;
            return blogPost;
        }


    }
}
