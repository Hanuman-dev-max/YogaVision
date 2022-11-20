

namespace YogaVision.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using YogaVision.Core.Contracts;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    public class YogaEventsService : IYogaEventsService
    {
        private readonly IDeletableEntityRepository<YogaEvent> yogaEventsRepository;
        public YogaEventsService(IDeletableEntityRepository<YogaEvent> yogaEventsRepository)
        {
            this.yogaEventsRepository = yogaEventsRepository;
        }
        public async Task AddAsync(string studioId, int instructorId, DateTime datetime, string description, string duration, int seats)
        {
            await this.yogaEventsRepository.AddAsync(new YogaEvent
            {
                Id = Guid.NewGuid().ToString(),
                DateTime = datetime,
                InstructorId = instructorId,
                StudioId = studioId,
                Description = description,
                CreatedOn = DateTime.Now,
                Duration = duration,
                Seats = seats,

            }); ;
            await this.yogaEventsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var yogaEvent =
                await this.yogaEventsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.yogaEventsRepository.Delete(yogaEvent);
            await this.yogaEventsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int? count = null)
        {
            var yogaEvent =
               await this.yogaEventsRepository
               .All()
               .OrderBy(x => x.DateTime)
               .To<T>().ToListAsync();
            return yogaEvent;
        }

        public async Task<IEnumerable<T>> GetAllByDateAsync<T>(DateTime dateTime, int? count = null)
        {
            var yogaEvent =
               await this.yogaEventsRepository
               .All()
               .Where(x => x.DateTime >= dateTime)
               .OrderBy(x => x.DateTime)
               .To<T>().ToListAsync();
            return yogaEvent;
        }

        public Task<IEnumerable<T>> GetAllWithPagingAsync<T>(int? sortId, int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetByCityIdAsync<T>(int cityId, DateTime dateTime)
        {
            var yogaEvent =
               await this.yogaEventsRepository
               .All()
               .Where(x => x.Studio.CityId == cityId && x.DateTime >= dateTime)
               .OrderBy(x => x.DateTime)
               .To<T>().ToListAsync();
            return yogaEvent;
        }

        public Task<T> GetByIdAsync<T>(string id)
        {
            throw new NotImplementedException();
        }



        public Task<int> GetCountForPaginationAsync()
        {
            throw new NotImplementedException();
        }
    }
}
