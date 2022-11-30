namespace YogaVision.Core.Contracts
{
    using YogaVision.Infrastructure.Data.Models;
    public interface ITagService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> GetCountForPaginationAsync();

        Task<T> GetByIdAsync<T>(int id);
        Task<T> GetByNameAsync<T>(string name);
        Task<int> AddAsync(string name);
        

        Task<List<int>> AddRangeAsync(List<string> tags);

        Task DeleteAsync(int id);
    }
}
