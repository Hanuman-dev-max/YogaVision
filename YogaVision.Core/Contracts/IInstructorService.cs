

namespace YogaVision.Core.Contracts
{
    public interface IInstructorService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> GetCountForPaginationAsync();

        Task<T> GetByIdAsync<T>(int id);

        Task AddAsync(string firstName, string lastName, string description, string nickName, string imageUrl, string imageUrlFirst, string imageUrlSecond, string imageUrlThird, string facebookLink);

        Task DeleteAsync(int id);


    }
}
