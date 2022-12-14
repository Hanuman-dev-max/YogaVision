namespace YogaVision.Core.Services
{
    using CloudinaryDotNet.Actions;
    using Microsoft.EntityFrameworkCore;
    using YogaVision.Core.Contracts;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class CityService : ICityService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CityService(IDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        /// <summary>
        /// Get all cities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Collection of type T</returns>
        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var cities =
                await this.citiesRepository
                .All()
                .OrderBy(x => x.Id)
                .To<T>().ToListAsync();
            return cities;
        }
        /// <summary>
        /// Add city to the database
        /// </summary>
        /// <param name="name">The name of the city</param>
        /// <returns></returns>
        public async Task AddAsync(string name)
        {
            await this.citiesRepository.AddAsync(new City
            {
                Name = name,
            });
            await this.citiesRepository.SaveChangesAsync();
        }
        /// <summary>
        /// Delete the city by Id
        /// </summary>
        /// <param name="id">The Id of the city</param>
        /// <returns></returns>

        public async Task DeleteAsync(int id)
        {
            var city =
                await this.citiesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.citiesRepository.Delete(city);
            await this.citiesRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Get city by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync<T>(int id)
        {
            var city =
                await this.citiesRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return city;
        }
        /// <summary>
        /// Get City Id by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<int> GetIdByNameAsync(string name)
        {
            var city =
             await this.citiesRepository
             .All()
             .Where(x => x.Name == name)
              .FirstOrDefaultAsync();
            if (city == null)
            {
                return -1;
            }
            return city.Id;
        }
        /// <summary>
        /// Edits City
        /// </summary>
        /// <param name="id">The Id of the City</param>
        /// <param name="name"The Name of the City></param>
        /// <returns></returns>
        public async Task EditAsync(int id, string name)
        {
            var city =
                await this.citiesRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (city == null)
            {
                throw new Exception($"Не същетвува студио с Id:{id}");
            }
            city.Name = name;
            await this.citiesRepository.SaveChangesAsync();

        }
    }
}
