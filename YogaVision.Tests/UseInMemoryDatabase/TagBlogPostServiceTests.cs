using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using YogaVision.Core.Contracts;
using YogaVision.Infrastructure.Data.Models;
using Assert = Xunit.Assert;

namespace YogaVision.Tests.UseInMemoryDatabase
{
    public class TagBlogPostServiceTests :BaseServiceTests
    {
        private ITagBlogPostService Service => this.ServiceProvider.GetRequiredService<ITagBlogPostService>();

        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {

            //Arrange
            await this.CreateTagBlogPostAsync();
           
            await this.Service.AddAsync(2, new List<int>() { 1, 2 });

            //Act
            var tagBlogPostsCount = await this.DbContext.TagBlogPosts.CountAsync();
            //Assert
            Assert.Equal(3, tagBlogPostsCount);
        }

        [Fact]
        public async Task GetTagByPostIdShouldReturnCorrectly()
        {
            //Arrage
            var tag1 = new Tag() { Id = 1, Name = "tag1" };
            var tag2 = new Tag() { Id = 2, Name = "tag2" };
            var tag3 = new Tag() { Id = 3, Name = "tag3" };
            var tagBlogPost1 = new TagBlogPost() { BlogPostId = 1, Tag = tag1 };
            var tagBlogPost2 = new TagBlogPost() { BlogPostId = 1, Tag = tag2 };
            var tagBlogPost3 = new TagBlogPost() { BlogPostId = 1, Tag = tag3 };
            await this.DbContext.TagBlogPosts.AddRangeAsync(new List<TagBlogPost>() { tagBlogPost1,tagBlogPost2,tagBlogPost3});
            await this.DbContext.SaveChangesAsync();
            //Act
            var actualTags = await this.Service.GetTagByPostId(1);
            
            //Assert
            Assert.Equal(new List<string>() {"tag1", "tag2", "tag3"}, actualTags);


        }



        private async Task<TagBlogPost> CreateTagBlogPostAsync()
        {

            var tagBlogPost = new TagBlogPost
            {
                 TagId = 1,
                 BlogPostId = 1,
            };

            await this.DbContext.TagBlogPosts.AddAsync(tagBlogPost);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<TagBlogPost>(tagBlogPost).State = EntityState.Detached;
            return tagBlogPost;
        }
    }
}
