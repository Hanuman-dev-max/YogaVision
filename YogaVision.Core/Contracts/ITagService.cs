namespace YogaVision.Core.Contracts
{
    using YogaVision.Infrastructure.Data.Models;
    /// <summary>
    /// Interface for Tag Service
    /// </summary>
    public interface ITagService
    {
        /// <summary>
        /// Gets all tags
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Collection of type T</returns>
        Task<IEnumerable<T>> GetAllAsync<T>();
        /// <summary>
        /// Gets by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The Id of the tag</param>
        /// <returns>Object of type T</returns>
        Task<T> GetByIdAsync<T>(int id);
        /// <summary>
        /// Gets tag by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name of the tag</param>
        /// <returns>Objecy of type T</returns>
        Task<T> GetByNameAsync<T>(string name);
        /// <summary>
        /// Adds tag
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<int> AddAsync(string name);
        /// <summary>
        /// Adds tags by their names
        /// </summary>
        /// <param name="tags">The names of the tags</param>
        /// <returns>List of int their Ids</returns>
        Task<ICollection<int>> AddRangeAsync(ICollection<string> tags);
        /// <summary>
        /// Deletes a tag by its Id
        /// </summary>
        /// <param name="Id">The Id of the tag</param>
        /// <returns></returns>
        Task DeleteAsync(int Id);
    }
}
