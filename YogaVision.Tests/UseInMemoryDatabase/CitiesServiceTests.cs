namespace YogaVision.Tests.UseInMemoryDatabase
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using YogaVision.Core.Contracts;
    using YogaVision.Infrastructure.Data.Models;

    public class CitiesServiceTests : BaseServiceTests
    {
        private ICityService Service => this.ServiceProvider.GetRequiredService<ICityService>();



        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            await this.CreateCityAsync();

            var name = new NLipsum.Core.Word().ToString();

            await this.Service.AddAsync(name);

            var citiesCount = await this.DbContext.Cities.CountAsync();
            Assert.Equal(2, citiesCount);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var city = await this.CreateCityAsync();

            await this.Service.DeleteAsync(city.Id);

            var citysCount = this.DbContext.Cities.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedCity = await this.DbContext.Cities.FirstOrDefaultAsync(x => x.Id == city.Id);
            Assert.Equal(0, citysCount);
            Assert.Null(deletedCity);
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
