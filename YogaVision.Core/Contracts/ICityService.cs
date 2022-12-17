
namespace YogaVision.Core.Contracts
{
  
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICityService
    {
        /// <summary>
        /// Get all cities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Collection of type T</returns>
        Task<IEnumerable<T>> GetAllAsync<T>();
        /// <summary>
        /// Add city to the database
        /// </summary>
        /// <param name="name">The name of the city</param>
        /// <returns></returns>
        Task AddAsync(string name);
        /// <summary>
        /// Delete the city by Id
        /// </summary>
        /// <param name="id">The Id of the city</param>
        /// <returns></returns>
        
        Task DeleteAsync(int id);
        /// <summary>
        /// Get city by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync<T>(int id);
        /// <summary>
        /// Get City Id by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<int> GetIdByNameAsync(string name);
        /// <summary>
        /// Edits City
        /// </summary>
        /// <param name="id">The Id of the City</param>
        /// <param name="name"The Name of the City></param>
        /// <returns></returns>
        Task EditAsync(int id, string name);
    }
}
