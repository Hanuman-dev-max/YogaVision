namespace YogaVision.Core.Services
{

    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Common;
    using YogaVision.Infrastructure.Data.Models;
    using YogaVision.Core.Contracts;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Service FoodRecipe  
    /// </summary>
    public class FoodRecipeService :IFoodRecipeService
    {
        private readonly IDeletableEntityRepository<FoodRecipe> foodRecipesRepository;

        public FoodRecipeService(IDeletableEntityRepository<FoodRecipe> foodRecipesRepository)
        {
            this.foodRecipesRepository = foodRecipesRepository;
        }
        /// <summary>
        ///  Gets all Food Recepes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count">The count of the food recipes to take</param>
        /// <returns>Collection of type T</returns>
        public async Task<IEnumerable<T>> GetAllAsync<T>(int? count = null)
        {
            IQueryable<FoodRecipe> query =
                this.foodRecipesRepository
                .All()
                .OrderByDescending(x => x.CreatedOn);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }
            return await query.To<T>().ToListAsync();
        }
        /// <summary>
        /// Gets all Food Recpes with paging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sortId">The Id of food recipes</param>
        /// <param name="pageSize">The size of the page</param>
        /// <param name="pageIndex">The page index</param>
        /// <returns>Collection of type T</returns>
        public async Task<IEnumerable<T>> GetAllWithPagingAsync<T>(
            int? sortId,
            int pageSize,
            int pageIndex)
        {
            IQueryable<FoodRecipe> query =
                this.foodRecipesRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn);
            if (sortId != null)
            {
                query = query
                    .Where(x => x.Id == sortId);
            }
            return await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).To<T>().ToListAsync();
        }
        /// <summary>
        /// Gets the count of all food recipes
        /// </summary>
        /// <returns>The count of food recipes</returns>
        public async Task<int> GetCountForPaginationAsync()
        {
            return await this.foodRecipesRepository
                .AllAsNoTracking()
                .CountAsync();

            
        }
        /// <summary>
        /// Gets FoodRecepe by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The Id of FoodRecipe</param>
        /// <returns>Object of type T</returns>
        public async Task<T> GetByIdAsync<T>(int id)
        {
            var foodRecipe =
                await this.foodRecipesRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return foodRecipe;
        }
        /// <summary>
        /// Adds FoodRecipe to the database
        /// </summary>
        /// <param name="title">The Title of the food recipe</param>
        /// <param name="requiredProducts">The Required products for the food recipe</param>
        /// <param name="content">The Content of the food recipe </param>
        /// <param name="author">The Author of the food recipe</param>
        /// <param name="imageUrl">The imageUrl of the food recipe</param>
        /// <returns>Object of type T</returns>
        public async Task AddAsync(string title,string requiredProducts, string content, string author, string imageUrl)
        {
            await this.foodRecipesRepository.AddAsync(new FoodRecipe
            {
                Title = title,
                RequiredProducts = requiredProducts,
                Content = content,
                Author = author,
                ImageUrl = imageUrl,
            });
            await this.foodRecipesRepository.SaveChangesAsync();
        }
        /// <summary>
        /// Deletes 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var foodRecipe =
                await this.foodRecipesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.foodRecipesRepository.Delete(foodRecipe);
            await this.foodRecipesRepository.SaveChangesAsync();
        }
    }
}

