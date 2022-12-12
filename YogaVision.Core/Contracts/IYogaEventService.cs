namespace YogaVision.Core.Contracts
{
    /// <summary>
    /// Interface for YogaEvent Service
    /// </summary>
    public interface IYogaEventService
    {
        /// <summary>
        /// Gets all Yoga Events
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync<T>();
        /// <summary>
        /// Gets all YogaEvent after a given date
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllByDateAsync<T>(DateTime dateTime);
        /// <summary>
        /// Gets YogaEvent by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The Id of YogaEvent</param>
        /// <returns></returns>
        Task<T> GetByIdAsync<T>(string id);
        /// <summary>
        /// Gets all Yoga Events by City
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cityId">The Id of the city</param>
        /// <param name="dateTime">The datetime after the YogaEvents will be taken</param>
        /// <returns>Collection of type T</returns>
        Task<IEnumerable<T>> GetByCityIdAsync<T>(int cityId, DateTime dateTime);
        /// <summary>
        /// Substarct one free seat from YogaEvent
        /// </summary>
        /// <param name="yogaEventId">The Id of YogaEvent</param>
        /// <returns></returns>
        Task SubstarctSeat(string yogaEventId);
        /// <summary>
        /// Add seat to YogaEvent
        /// </summary>
        /// <param name="yogaEventId">The Id of YogaEvent</param>
        /// <returns></returns>
        Task AddSeat(string yogaEventId);
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
        Task AddAsync(int studioId, int instructorId, DateTime datetime, string description, string duration, int seats);
        /// <summary>
        /// Deletes YogaEvent
        /// </summary>
        /// <param name="id">The Id of the YogaEvent</param>
        /// <returns></returns>
        Task DeleteAsync(string id);
        Task<IEnumerable<T>> GetAllByDateAndUserIdAsync<T>(DateTime dateTime, string userId);
        Task EditAsync(string yogaEventId, int studioId, int instructorId, DateTime datetime, string description, string duration, int seats);

    }
}
