

namespace YogaVision.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using YogaVision.Core.Contracts;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Models;
    public class StudiosService : IStudiosService
    {
        private readonly IDeletableEntityRepository<Studio> studiosRepository;

        public StudiosService(IDeletableEntityRepository<Studio> studiosRepository)
        {
            this.studiosRepository = studiosRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var salons =
                await this.studiosRepository
                .All()
                .OrderBy(x => x.Name)
                .To<T>().ToListAsync();
            return salons;
        }

        public async Task<IEnumerable<T>> GetAllWithSortingFilteringAndPagingAsync<T>(
            string searchString,
            int? sortId,
            int pageSize,
            int pageIndex)
        {
            IQueryable<Studio> query =
                this.studiosRepository
                .AllAsNoTracking()
                .OrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query
                    .Where(x => x.Name.ToLower()
                                .Contains(searchString.ToLower()));
            }



            return await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .To<T>().ToListAsync();
        }

        public async Task<int> GetCountForPaginationAsync(string searchString, int? sortId)
        {
            IQueryable<Studio> query =
                this.studiosRepository
                .AllAsNoTracking()
                .OrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query
                    .Where(x => x.Name.ToLower()
                                .Contains(searchString.ToLower()));
            }



            return await query.CountAsync();
        }



        public async Task<T> GetByIdAsync<T>(string id)
        {
            var studio =
                await this.studiosRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return studio;
        }

        public async Task<string> AddAsync(string name, int cityId, string address, string imageUrl)
        {
            var studio = new Studio
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,

                CityId = cityId,
                Address = address,
                ImageUrl = imageUrl,
            };

            await this.studiosRepository.AddAsync(studio);
            await this.studiosRepository.SaveChangesAsync();
            return studio.Id;
        }

        public async Task DeleteAsync(string id)
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
