

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

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var studios =
                await this.studiosRepository
                .All()
                .OrderBy(x => x.Name)
                .To<T>().ToListAsync();
            return studios;
        }
        public async Task<T> GetByIdAsync<T>(int id)
        {
            var studio =
                await this.studiosRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return studio;
        }
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
    }
}
