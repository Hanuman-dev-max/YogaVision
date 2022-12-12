

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
    /// <summary>
    /// Service for YogaEvent
    /// </summary>
    public class YogaEventService : IYogaEventService
    {
        private readonly IDeletableEntityRepository<YogaEvent> yogaEventsRepository;
        public YogaEventService(IDeletableEntityRepository<YogaEvent> yogaEventsRepository)
        {
            this.yogaEventsRepository = yogaEventsRepository;
        }
        /// <summary>
        /// Adds YogaEvent 
        /// </summary>
        /// <param name="studioId">The Id of the studio</param>
        /// <param name="instructorId">The Id of the instructor</param>
        /// <param name="datetime">The datetime on which the YogaEvent will start</param>
        /// <param name="description">The description of the YogaEvent</param>
        /// <param name="duration">The duration of the YogaEvent</param>
        /// <param name="seats">The free seats of the YogaEvent</param>
        /// <returns></returns>
        public async Task AddAsync(int studioId, int instructorId, DateTime datetime, string description, string duration, int seats)
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
        /// <summary>
        /// Add seat to YogaEvent
        /// </summary>
        /// <param name="yogaEventId">The Id of YogaEvent</param>
        /// <returns></returns>
        public async Task AddSeat(string yogaEventId)
        {
            var yogaEvent =
                await this.yogaEventsRepository
                .All()
                .Where(x => x.Id == yogaEventId).
                FirstOrDefaultAsync();

            yogaEvent.Seats += 1;
            await this.yogaEventsRepository.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes YogaEvent
        /// </summary>
        /// <param name="id">The Id of the YogaEvent</param>
        /// <returns></returns>
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

        public async Task EditAsync(string yogaEventId, int studioId, int instructorId, DateTime datetime, string description, string duration, int seats)
        {
            var yogaEvent =
               await this.yogaEventsRepository
               .All()
               .Where(x => x.Id == yogaEventId)
               .FirstOrDefaultAsync();

            if (yogaEvent == null)
            {
                throw new Exception($"Не съществува събитиес с Id{yogaEventId}");
            }
            yogaEvent.StudioId = studioId;
            yogaEvent.InstructorId = instructorId;
            yogaEvent.DateTime = datetime;
            yogaEvent.Description = description;
            yogaEvent.Duration = duration;
            yogaEvent.Seats = seats;

            await this.yogaEventsRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all Yoga Events
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var yogaEvent =
               await this.yogaEventsRepository
               .All()
               .OrderBy(x => x.DateTime)
               .To<T>().ToListAsync();
            return yogaEvent;
        }

        public async Task<IEnumerable<T>> GetAllByDateAndUserIdAsync<T>(DateTime dateTime, string userId)
        {
            var yogaEvent =
                           await this.yogaEventsRepository
                           .All()
                           .Where(x => x.DateTime >= dateTime && x.Users.Any(u => u.ApplicationUserId == userId))
                           .OrderBy(x => x.DateTime)
                           .To<T>().ToListAsync();
            return yogaEvent;
        }

        /// <summary>
        /// Gets all YogaEvent after a given date
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllByDateAsync<T>(DateTime dateTime)
        {
            var yogaEvent =
               await this.yogaEventsRepository
               .All()
               .Where(x => x.DateTime >= dateTime)
               .OrderBy(x => x.DateTime)
               .To<T>().ToListAsync();
            return yogaEvent;
        }
        /// <summary>
        /// Gets all Yoga Events by City
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cityId">The Id of the city</param>
        /// <param name="dateTime">The datetime after the YogaEvents will be taken</param>
        /// <returns>Collection of type T</returns>
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
        /// <summary>
        /// Gets YogaEvent by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The Id of YogaEvent</param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync<T>(string id)
        {
            var yogaEvent =
                await this.yogaEventsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return yogaEvent;
        }
        /// <summary>
        /// Substarct one free seat from YogaEvent
        /// </summary>
        /// <param name="yogaEventId">The Id of YogaEvent</param>
        /// <returns></returns>
        public async Task SubstarctSeat(string yogaEventId)
        {
            var yogaEvent =
                await this.yogaEventsRepository
                .All()
                .Where(x => x.Id == yogaEventId).
                FirstOrDefaultAsync();
            if (yogaEvent.Seats == 0)
            {
                throw new Exception("Seats cannot be negative");
            }


            yogaEvent.Seats -= 1;
            await this.yogaEventsRepository.SaveChangesAsync();
        }
    }
}
