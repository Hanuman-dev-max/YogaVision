namespace YogaVision.Core.Contracts
{

    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IStudioService
    {
        /// <summary>
        /// Get all studios
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Collection of type T</returns>
        Task<IEnumerable<T>> GetAllAsync<T>();
        /// <summary>
        /// Get studio by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The Id of the studio</param>
        /// <returns>Object of type T</returns>
        Task<T> GetByIdAsync<T>(int id);
        /// <summary>
        /// Add studio
        /// </summary>
        /// <param name="name">The name of the studio</param>
        /// <param name="cityId">The City Id of the studio</param>
        /// <param name="address">The address of the studio</param>
        /// <param name="imageUrl">ImageUrl of the studio </param>
        /// <returns>Return the Id the studio</returns>
        Task<int> AddAsync(string name, int cityId, string address, string imageUrl);
        /// <summary>
        /// Delete studio by Id
        /// </summary>
        /// <param name="id">The Id the studio</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
