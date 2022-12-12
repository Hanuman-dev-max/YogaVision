

namespace YogaVision.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using YogaVision.Core.Contracts;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Models;
    public class StudioService : IStudioService
    {
        private readonly IDeletableEntityRepository<Studio> studiosRepository;

        public StudioService(IDeletableEntityRepository<Studio> studiosRepository)
        {
            this.studiosRepository = studiosRepository;
        }

        /// <summary>
        /// Get all studios
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Collection of type T</returns>
        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var studios =
                await this.studiosRepository
                .All()
                .OrderBy(x => x.Name)
                .To<T>().ToListAsync();
            return studios;
        }
        /// <summary>
        /// Get studio by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The Id of the studio</param>
        /// <returns>Object of type T</returns>
        public async Task<T> GetByIdAsync<T>(int id)
        {
            var studio =
                await this.studiosRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return studio;
        }
        /// <summary>
        /// Add studio
        /// </summary>
        /// <param name="name">The name of the studio</param>
        /// <param name="cityId">The City Id of the studio</param>
        /// <param name="address">The address of the studio</param>
        /// <param name="imageUrl">ImageUrl of the studio </param>
        /// <returns>Return the Id the studio</returns>
        public async Task<int> AddAsync(string name, int cityId, string address, string imageUrl)
        {
            var studio = new Studio
            {
                Name = name,
                CityId = cityId,
                Address = address,
                ImageUrl = imageUrl,
            };

            await this.studiosRepository.AddAsync(studio);
            await this.studiosRepository.SaveChangesAsync();
            return studio.Id;
        }
        /// <summary>
        /// Delete studio by Id
        /// </summary>
        /// <param name="id">The Id the studio</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var studio =
                await this.studiosRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.studiosRepository.Delete(studio);
            await this.studiosRepository.SaveChangesAsync();
        }
        /// <summary>
        /// Get studio Id by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<int> GetIdByNameAsync(string name)
        {
            var studio =
             await this.studiosRepository
             .All()
             .Where(x => x.Name == name)
              .FirstOrDefaultAsync();
            if (studio == null)
            {
                return -1;
            }
            return studio.Id;
        }

    }
    
}
