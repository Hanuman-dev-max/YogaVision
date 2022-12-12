namespace YogaVision.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;
    using YogaVision.Core.Models.FoodRecipe;
    using YogaVision.Core.Models.Pagination;
    using YogaVision.Core.Services;
    /// <summary>
    /// Controller for FoodRecipe model
    /// </summary>
    public class FoodRecipeController : BaseController
    {
        private readonly IFoodRecipeService foodRecipesService;

        /// <summary>
        /// Constructor for FoodRecipeController
        /// </summary>
        /// <param name="foodRecipesService">Interface of type IFoodRecipeService</param>
        public FoodRecipeController(IFoodRecipeService foodRecipesService)
        {
            this.foodRecipesService = foodRecipesService;
        }

        /// <summary>
        /// Displays Index View
        /// </summary>
        /// <param name="sortId">The Id of FoodRecipe</param>
        /// <param name="pageNumber">The Number of the page78</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(
            int? sortId,
            int? pageNumber) 
        {
            if (sortId != null)
            {
                var foodRecipe = await this.foodRecipesService
                    .GetByIdAsync<FoodRecipeViewModel>(sortId.Value);
                if (foodRecipe == null)
                {
                    return new StatusCodeResult(404);
                }
            }

            this.ViewData["CurrentSort"] = sortId;

            int pageSize = PageSizesConstants.FoodRecipess;
            var pageIndex = pageNumber ?? 1;

            var foodRecipes = await this.foodRecipesService
                .GetAllWithPagingAsync<FoodRecipeViewModel>(sortId, pageSize, pageIndex);
            var firstRowfoodRecipesList = foodRecipes.Take(3).ToList();
            var secondRowfoodRecipesList = foodRecipes.Skip(3).ToList();

            var count = await this.foodRecipesService.GetCountForPaginationAsync();

            var viewModel = new FoodRecipesPaginatedListViewModel
            {
               FirstRowFoodRecipes = new PaginatedList<FoodRecipeViewModel>(firstRowfoodRecipesList, count, pageIndex, pageSize),
               SecondRowFoodRecipes = new PaginatedList<FoodRecipeViewModel>(secondRowfoodRecipesList, count, pageIndex, pageSize),
            };

            return this.View(viewModel);
        }
        /// <summary>
        /// Displays Details View
        /// </summary>
        /// <param name="id">The Id of FoodRecipe</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            var foodRecipe = await foodRecipesService.GetByIdAsync<FoodRecipeViewModel>(id);
            return View(foodRecipe);
        }
    }
}
