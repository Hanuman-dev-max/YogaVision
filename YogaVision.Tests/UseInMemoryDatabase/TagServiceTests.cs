namespace YogaVision.Tests.UseInMemoryDatabase
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using Xunit;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.City;
    using YogaVision.Core.Models.Tag;
    using YogaVision.Infrastructure.Data.Models;
    using Assert = Xunit.Assert;

    public class TagServiceTests:BaseServiceTests
    {
        private ITagService Service => this.ServiceProvider.GetRequiredService<ITagService>();

        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {

            //Arrange
            await this.CreateTagAsync();
            var name = new NLipsum.Core.Word().ToString();
            await this.Service.AddAsync(name);
            await this.Service.AddAsync(name);

            //Act
            var tagsCount = await this.DbContext.Tags.CountAsync();
            //Assert
            Assert.Equal(2, tagsCount);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            //Arrange
            var tag = await this.CreateTagAsync();
            await this.Service.DeleteAsync(tag.Id);
            //Act
            var tagsCount = this.DbContext.Tags.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedTag = await this.DbContext.Tags.FirstOrDefaultAsync(x => x.Id == tag.Id);
            //Assert
            Assert.Equal(0, tagsCount);
            Assert.Null(deletedTag);
        }
        [Fact]
        public async Task GetByIdShouldReturnCorrectly()
        {
            //Arranege
            var tag = await this.CreateTagAsync();

            //Act
            var actualTag = await this.Service.GetByIdAsync<TagViewModel>(tag.Id);
            //Assert
            Assert.Equal(tag.Name, actualTag.Name);

        }
        [Fact]
        public async Task GetAllAsyncShouldReturnCorrectly()
        {
            //Arrange
            var city = await this.CreateTagAsync();
            //Act
            var ActualTags = await this.Service.GetAllAsync<TagViewModel>();
            //Assert
            Assert.Equal(1, ActualTags.Count());
        }

        [Fact]
        public async Task GetByNameAsyncShouldReturnCorrectly()
        {
            //Arrange
            var tag = await this.CreateTagAsync();
            //Act
            var ActuralTag = await this.Service.GetByNameAsync<TagViewModel>(tag.Name);
            //Assert
            Assert.Equal(tag.Id, ActuralTag.Id);
        }

        [Fact]
        public async Task AddRangeAsyncShouldReturnCorrectly()
        {
            //Arrange
            var tag1 = new Tag
            {
                Name ="tag1",
            };

            await this.DbContext.Tags.AddAsync(tag1);
            await this.DbContext.SaveChangesAsync(); 
            var tag2 = new Tag
            {
                Name = "tag2",
            };
            await this.DbContext.Tags.AddAsync(tag2);
            await this.DbContext.SaveChangesAsync();
            var tag3 = new Tag
            {
                Name = "tag3",
            };
            await this.DbContext.Tags.AddAsync(tag3);
            await this.DbContext.SaveChangesAsync();
            //Act
            var ActualTagIds = await this.Service.AddRangeAsync(new List<string>(){"tag1", "tag3", "tag4"});
            //Assert
            Assert.Equal(new List<int>() { 1, 3, 4 }, ActualTagIds);
        }

        private async Task<Tag> CreateTagAsync()
        {

            var tag = new Tag
            {
                Name = "tag",
            };

            await this.DbContext.Tags.AddAsync(tag);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Tag>(tag).State = EntityState.Detached;
            return tag;
        }



    }
}
