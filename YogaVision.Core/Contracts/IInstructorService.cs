namespace YogaVision.Core.Contracts
{
    /// <summary>
    /// Inteface for InstructorService
    /// </summary>
    public interface IInstructorService
    {
        /// <summary>
        /// Gets all instructors
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count">The number of instructors to be taken</param>
        /// <returns>Collection of type T</returns>
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);
        /// <summary>
        /// Get instructor by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync<T>(int id);
        /// <summary>
        /// Adds Instructor to the database
        /// </summary>
        /// <param name="firstName"The First name of the Instructor</param>
        /// <param name="lastName">The Last name of the Instructor</param>
        /// <param name="description">The Description of the Instructor</param>
        /// <param name="nickName">The Nickname of the Instructor</param>
        /// <param name="imageUrl">The main picture of the Instructor</param>
        /// <param name="imageUrlFirst">The First pic of the Instructor</param>
        /// <param name="imageUrlSecond">The Second pic of the Instructor</param>
        /// <param name="imageUrlThird">The Third poc of the Instructor</param>
        /// <param name="facebookLink">Facebook link of the Instructor</param>
        /// <returns></returns>
        Task AddAsync(string firstName, string lastName, string description, string nickName, string imageUrl, string imageUrlFirst, string imageUrlSecond, string imageUrlThird, string facebookLink);

        /// <summary>
        /// Deletes Instructor by Id
        /// </summary>
        /// <param name="id">The Id of the Instructor</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
        /// <summary>
        /// Get instructor by NickName
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Id of the instructor</returns>
        Task<int> GetIdByNickNameAsync(string nickName);


    }
}
