

namespace YogaVision.Core.Contracts
{
    /// <summary>
    /// Interface for Service FoodRecipe  
    /// </summary>
    public interface IFoodRecipeService
    {
        /// <summary>
        ///  Gets all Food Recepes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count">The count of the food recipes to take</param>
        /// <returns>Collection of type T</returns>
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        /// <summary>
        /// Gets all Food Recpes with paging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sortId">The Id of food recipes</param>
        /// <param name="pageSize">The size of the page</param>
        /// <param name="pageIndex">The page index</param>
        /// <returns>Collection of type T</returns>
        Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex);
        /// <summary>
        /// Gets the count of all food recipes
        /// </summary>
        /// <returns>The count of food recipes</returns>
        Task<int> GetCountForPaginationAsync();
        /// <summary>
        /// Gets FoodRecepe by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The Id of FoodRecipe</param>
        /// <returns>Object of type T</returns>
        Task<T> GetByIdAsync<T>(int id);
        /// <summary>
        /// Adds FoodRecipe to the database
        /// </summary>
        /// <param name="title">The Title of the food recipe</param>
        /// <param name="requiredProducts">The Required products for the food recipe</param>
        /// <param name="content">The Content of the food recipe </param>
        /// <param name="author">The Author of the food recipe</param>
        /// <param name="imageUrl">The imageUrl of the food recipe</param>
        /// <returns>Object of type T</returns>
        Task AddAsync(string title,string requiredProducts, string content, string author, string imageUrl);
        /// <summary>
        /// Deletes 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
        /// <summary>
        /// Edits FoodRecipe
        /// </summary>
        /// <param name="id">The Id of the FoodRecipe</param>
        /// <param name="title">The Title of the food recipe</param>
        /// <param name="requiredProducts">The Required products for the food recipe</param>
        /// <param name="content">The Content of the food recipe </param>
        /// <param name="author">The Author of the food recipe</param>
        /// <param name="imageUrl">The imageUrl of the food recipe</param>
        /// <returns></returns>
        Task EditAsync(int id, string title, string requiredProducts, string content, string author, string imageUrl);
    }
}
