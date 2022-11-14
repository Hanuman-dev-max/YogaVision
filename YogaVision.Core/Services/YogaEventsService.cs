using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaVision.Common;
using YogaVision.Core.Contracts;
using static YogaVision.Common.GlobalConstants;
using YogaVision.Core.Models.Common;
using YogaVision.Infrastructure.Data.Common;
using YogaVision.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using YogaVision.Infrastructure.Data.Common.Mapping;

namespace YogaVision.Core.Services
{
    public class YogaEventsService : IYogaEventsService
    {
        private readonly IDeletableEntityRepository<YogaEvent> yogaEventsRepository;
        public YogaEventsService(IDeletableEntityRepository<YogaEvent> yogaEventsRepository)
        {
            this.yogaEventsRepository = yogaEventsRepository; 
        }
        public async Task AddAsync(string studioId, int instructorId,  DateTime datetime, string description, string duration)
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
                   
            });
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
               .OrderByDescending(x => x.DateTime)
               .To<T>().ToListAsync();
            return yogaEvent;
        }

        public Task<IEnumerable<T>> GetAllWithPagingAsync<T>(int? sortId, int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
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
