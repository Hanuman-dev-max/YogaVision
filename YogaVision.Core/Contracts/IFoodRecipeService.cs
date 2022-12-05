﻿

namespace YogaVision.Core.Contracts
{
    public interface IFoodRecipeService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> GetCountForPaginationAsync();

        Task<T> GetByIdAsync<T>(int id);

        Task AddAsync(string title,string requiredProducts, string content, string author, string imageUrl, DateTime createdOn);

        Task DeleteAsync(int id);

    }
}
