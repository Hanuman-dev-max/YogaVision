namespace YogaVision.Core.Contracts
{
    public interface IYogaEventsService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> GetCountForPaginationAsync();

        Task<T> GetByIdAsync<T>(string id);

        Task AddAsync(string studioId, int instructorId, DateTime datetime, string description, string duration, int seats);

        Task DeleteAsync(string id);
    }
}
