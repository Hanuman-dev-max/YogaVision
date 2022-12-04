namespace YogaVision.Core.Contracts
{
    public interface IYogaEventService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);
        Task<IEnumerable<T>> GetAllByDateAsync<T>(DateTime dateTime, int? count = null);

        Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> GetCountForPaginationAsync();

        Task<T> GetByIdAsync<T>(string id);
        Task<IEnumerable<T>> GetByCityIdAsync<T>(int cityId, DateTime dateTime);

        Task SubstarctSeat(string yogaEventId);

        Task AddSeat(string yogaEventId);

        Task AddAsync(int studioId, int instructorId, DateTime datetime, string description, string duration, int seats);

        // Task AddUserToEvent(string yogaEventId, string userId);
        Task DeleteAsync(string id);


    }
}
