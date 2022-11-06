namespace YogaVision.Core.Services
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Models;
    using YogaVision.Core.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class InstructorsService : IInstructorsService
    {
        private readonly IDeletableEntityRepository<Instructor> instructorRepository;

        public InstructorsService(IDeletableEntityRepository<Instructor> instructorRepository)
        {
            this.instructorRepository = instructorRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int? count = null)
        {
            IQueryable<Instructor> query =
                this.instructorRepository
                .All()
                .OrderByDescending(x => x.CreatedOn);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }



            return await query.To<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex)
        {
            IQueryable<Instructor> query =
                this.instructorRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn);

            if (sortId != null)
            {
                query = query
                    .Where(x => x.Id == sortId);
            }

            return await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).To<T>().ToListAsync();
        }

        public async Task<int> GetCountForPaginationAsync()
        {
            return await this.instructorRepository
                .AllAsNoTracking()
                .CountAsync();

            // return await query.CountAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var instructor =
                await this.instructorRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return instructor;
        }

        public async Task AddAsync(string firstName, string lastName, string description, string nickName, string imageUrl)
        {
            await this.instructorRepository.AddAsync(new Instructor
            {
                Description = description,
                 FirstName = firstName,
                  LastName = lastName,
                   Nickname = nickName,
                ImageUrl = imageUrl,
            });
            await this.instructorRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var instructor =
                await this.instructorRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.instructorRepository.Delete(instructor);
            await this.instructorRepository.SaveChangesAsync();
        }
    }
}

