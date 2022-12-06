namespace YogaVision.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using YogaVision.Core.Contracts;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Models;
    /// <summary>
    /// Service for YogaEventApplicationUser
    /// </summary>
    public class YogaEventApplicationUserService : IYogaEventApplicationUserService
    {
        private readonly IDeletableEntityRepository<YogaEventApplicationsUser> yogaEventApplicationUserRepository;

        public YogaEventApplicationUserService(IDeletableEntityRepository<YogaEventApplicationsUser> yogaEventApplicationUserRepository)
        {
            this.yogaEventApplicationUserRepository = yogaEventApplicationUserRepository;
        }
        /// <summary>
        /// Adds YogaEventApplicationUser
        /// </summary>
        /// <param name="yogaEventId">The Id of YogaEvent</param>
        /// <param name="ApplicationUserId">The Id of ApplicationUser</param>
        /// <returns></returns>
        public async Task AddAsync(string yogaEventId, string applicationUserId)
        {
            var yogaEventApplicationsUser =
                await this.yogaEventApplicationUserRepository
                .AllWithDeleted()
                .Where(x => x.YogaEventId == yogaEventId && x.ApplicationUserId == applicationUserId)
                .FirstOrDefaultAsync();
            if (yogaEventApplicationsUser == null)
            {
                await this.yogaEventApplicationUserRepository.AddAsync(new YogaEventApplicationsUser
                {
                    ApplicationUserId = applicationUserId,
                    YogaEventId = yogaEventId,

                });
                await this.yogaEventApplicationUserRepository.SaveChangesAsync();
            }
            else
            {
                yogaEventApplicationsUser.IsDeleted = false;
                await this.yogaEventApplicationUserRepository.SaveChangesAsync();
            }

        }
        /// <summary>
        /// Checks if User participates in YogaEvent
        /// </summary>
        /// <param name="yogaEventId">The Id of YogaEvent</param>
        /// <param name="ApplicationUserId">The Id of ApplicationUser</param>
        /// <returns></returns>
        public bool CheckUserInEvent(string yogaEventId, string ApplicationUserId)
        {
            bool result = this.yogaEventApplicationUserRepository
                .All()
                .Any(x => x.YogaEventId == yogaEventId && x.ApplicationUserId == ApplicationUserId);

            return result;
        }
        /// <summary>
        /// Deletes  YogaEventApplicationUser
        /// </summary>
        /// <param name="yogaEventId">The Id of YogaEvent</param>
        /// <param name="ApplicationUserId">The Id of ApplicationUser</param>
        /// <returns></returns>
        public async Task DeleteAsync(string yogaEventId, string applicationUserId)
        {
            var yogaEventApplicationsUser =
                await this.yogaEventApplicationUserRepository
                .AllAsNoTracking()
                .Where(x => x.YogaEventId == yogaEventId && x.ApplicationUserId == applicationUserId)
                .FirstOrDefaultAsync();
            this.yogaEventApplicationUserRepository.Delete(yogaEventApplicationsUser);
            await this.yogaEventApplicationUserRepository.SaveChangesAsync();
        }
    }
}
