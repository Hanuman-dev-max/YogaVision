namespace YogaVision.Core.Contracts
{
    /// <summary>
    ///Interface for YogaEventApplicationUser Service 
    /// </summary>
    public interface IYogaEventApplicationUserService
    {
        /// <summary>
        /// Adds YogaEventApplicationUser
        /// </summary>
        /// <param name="yogaEventId">The Id of YogaEvent</param>
        /// <param name="ApplicationUserId">The Id of ApplicationUser</param>
        /// <returns></returns>
        Task AddAsync(string yogaEventId, string ApplicationUserId);
        /// <summary>
        /// Checks if User participates in YogaEvent
        /// </summary>
        /// <param name="yogaEventId">The Id of YogaEvent</param>
        /// <param name="ApplicationUserId">The Id of ApplicationUser</param>
        /// <returns></returns>
        Task<bool> CheckUserInEvent(string yogaEventId, string ApplicationUserId);
        /// <summary>
        /// Deletes  YogaEventApplicationUser
        /// </summary>
        /// <param name="yogaEventId">The Id of YogaEvent</param>
        /// <param name="ApplicationUserId">The Id of ApplicationUser</param>
        /// <returns></returns>
        Task DeleteAsync(string yogaEventId, string ApplicationUserId);
    }
}
