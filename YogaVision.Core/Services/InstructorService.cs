namespace YogaVision.Core.Services
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Models;
    using YogaVision.Core.Contracts;
    using Microsoft.EntityFrameworkCore;
    /// <summary>
    /// Service for Instructor
    /// </summary>
    public class InstructorService : IInstructorService
    {
        private readonly IDeletableEntityRepository<Instructor> instructorRepository;

        public InstructorService(IDeletableEntityRepository<Instructor> instructorRepository)
        {
            this.instructorRepository = instructorRepository;
        }

        /// <summary>
        /// Gets all instructors
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count">The number of instructors to be taken</param>
        /// <returns>Collection of type T</returns>
        public async Task<IEnumerable<T>> GetAllAsync<T>(int? count = null)
        {
            IQueryable<Instructor> query =
                this.instructorRepository
                .All()
                .OrderByDescending(x => x.Id);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }
            return await query.To<T>().ToListAsync();
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
        /// <summary>
        /// Adds Instructor to the database
        /// </summary>
        /// <param name="firstName"The First name of the Instructor</param>
        /// <param name="lastName">The Last name of the Instructor</param>
        /// <param name="description">The Description of the Instructor</param>
        /// <param name="nickName">The Nickname of the Instructor</param>
        /// <param name="imageUrl">The main picture of the Instructor</param>
        /// <param name="imageUrlFirst">The First pic of the Instructor</param>
        /// <param name="imageUrlSecond">The Second pic of the Instructor</param>
        /// <param name="imageUrlThird">The Third poc of the Instructor</param>
        /// <param name="facebookLink">Facebook link of the Instructor</param>
        /// <returns></returns>
        public async Task AddAsync(string firstName, string lastName, string description, string nickName, string imageUrl, string imageUrlFirst , string imageUrlSecond, string imageUrlThird, string facebookLink)
        {
            await this.instructorRepository.AddAsync(new Instructor
            {
                Description = description,
                 FirstName = firstName,
                  LastName = lastName,
                   Nickname = nickName,
                ImageUrl = imageUrl,
                ImageUrlFirst = imageUrlFirst,
                ImageUrlSecond = imageUrlSecond,
                ImageUrlThird = imageUrlThird,

                FacebookLink = facebookLink
            });
            await this.instructorRepository.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes Instructor by Id
        /// </summary>
        /// <param name="id">The Id of the Instructor</param>
        /// <returns></returns>
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
        /// <summary>
        /// Get instructor by NickName
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> GetIdByNickNameAsync(string nickName)
        {
            var instructor =
              await this.instructorRepository
              .All()
              .Where(x => x.Nickname == nickName)
               .FirstOrDefaultAsync();
            if (instructor == null)
            {
                return -1;
            }
            return instructor.Id;
        }
    }
}

