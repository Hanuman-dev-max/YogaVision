using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using YogaVision.Core.Contracts;
using YogaVision.Core.Models.City;
using YogaVision.Core.Models.Studio;
using YogaVision.Infrastructure.Data.Models;
using Assert = Xunit.Assert;

namespace YogaVision.Tests.UseInMemoryDatabase
{
    public class StudioServiceTests :BaseServiceTests
    {
        private IStudioService Service => this.ServiceProvider.GetRequiredService<IStudioService>();



        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {

            //Arrange
            await this.CreateStudioAsync();
            var name = new NLipsum.Core.Word().ToString();
            await this.Service.AddAsync(name, 1, new NLipsum.Core.Word().ToString(), new NLipsum.Core.Word().ToString());

            //Act
            var studiosCount = await this.DbContext.Studios.CountAsync();
            //Assert
            Assert.Equal(2, studiosCount);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            //Arrange
            var studio = await this.CreateStudioAsync();
            await this.Service.DeleteAsync(studio.Id);
            //Act
            var stuidiosCount = this.DbContext.Studios.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedStudio = await this.DbContext.Cities.FirstOrDefaultAsync(x => x.Id == studio.Id);
            //Assert
            Assert.Equal(0, stuidiosCount);
            Assert.Null(deletedStudio);
        }
        [Fact]
        public async Task GetByIdShouldReturnCorrectly()
        {
            //Arranege
            var studio = await this.CreateStudioAsync();

            //Act
            var actualStudio = await this.Service.GetByIdAsync<StudioSimpleViewModel>(studio.Id);
            //Assert
            Assert.Equal(studio.Name, actualStudio.Name);

        }
        [Fact]
        public async Task GetAllAsyncShouldReturnCorrectly()
        {
            //Arrange
            var studio = await this.CreateStudioAsync();
            //Act
            var ActualCities = await this.Service.GetAllAsync<StudioSimpleViewModel>();
            //Assert
            Assert.Equal(1, ActualCities.Count());
        }


        private async Task<Studio> CreateStudioAsync()
        {

            var studio = new Studio
            {
                Address = new NLipsum.Core.Word().ToString(),
                Name = new NLipsum.Core.Word().ToString(),
                 ImageUrl = new NLipsum.Core.Word().ToString(),
                  CityId = 1,
                   
            };

            await this.DbContext.Studios.AddAsync(studio);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Studio>(studio).State = EntityState.Detached;
            return studio;
        }
    }
}
