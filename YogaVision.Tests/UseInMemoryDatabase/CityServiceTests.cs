namespace YogaVision.Tests.UseInMemoryDatabase
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.City;
    using YogaVision.Infrastructure.Data.Models;

    public class CityServiceTests : BaseServiceTests
    {
        private ICityService Service => this.ServiceProvider.GetRequiredService<ICityService>();



        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            
            //Arrange
            await this.CreateCityAsync();
            var name = new NLipsum.Core.Word().ToString();
            await this.Service.AddAsync(name);
            
            //Act
            var citiesCount = await this.DbContext.Cities.CountAsync();
            //Assert
            Assert.Equal(2, citiesCount);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            //Arrange
            var city = await this.CreateCityAsync();
            await this.Service.DeleteAsync(city.Id);
            //Act
            var citysCount = this.DbContext.Cities.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedCity = await this.DbContext.Cities.FirstOrDefaultAsync(x => x.Id == city.Id);
            //Assert
            Assert.Equal(0, citysCount);
            Assert.Null(deletedCity);
        }
        [Fact]
        public async Task GetByIdShouldReturnCorrectly()
        {
            //Arranege
            var city = await this.CreateCityAsync();
          
            //Act
            var actualCity = await this.Service.GetByIdAsync<CityViewModel>(city.Id);
            //Assert
            Assert.Equal(city.Name, actualCity.Name);

        }
        [Fact]
        public async Task GetAllAsyncShouldReturnCorrectly()
        {
            //Arrange
            var city = await this.CreateCityAsync();
            //Act
            var ActualCities = await this.Service.GetAllAsync<CityViewModel>();
            //Assert
            Assert.Equal(1, ActualCities.Count());
        }
        [Fact]
        public async Task EditAsyncShouldReturnCorrectly()
        {
            //Arrange
            var city = await this.CreateCityAsync();
            //Act
            await this.Service.EditAsync(city.Id, "Test");
           var actualCity = await this.Service.GetByIdAsync<CityViewModel>(city.Id);

            //Assert
            Assert.Equal("Test", actualCity.Name );
        
        
        }

        private async Task<City> CreateCityAsync()
        {
            
            var city = new City
            {
                Name = new NLipsum.Core.Word().ToString(),
            };
            
            await this.DbContext.Cities.AddAsync(city);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<City>(city).State = EntityState.Detached;
            return city;
        }
    }
}
 