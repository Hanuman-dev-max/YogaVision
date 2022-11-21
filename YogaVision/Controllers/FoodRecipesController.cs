



namespace YogaVision.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPosts;
    using YogaVision.Core.Models.FoodRecipes;
    using YogaVision.Core.Models.Pagination;
    public class FoodRecipesController : BaseController
    {
        private readonly IFoodRecipesService foodRecipesService;

        public FoodRecipesController(IFoodRecipesService foodRecipesService)
        {
            this.foodRecipesService = foodRecipesService;
        }

        public async Task<IActionResult> Index(
            int? sortId,
            int? pageNumber) // blogPostId
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
            var foodRecipesList = foodRecipes.ToList();

            var count = await this.foodRecipesService.GetCountForPaginationAsync();

            var viewModel = new FoodRecipesPaginatedListViewModel
            {
                FoodRecipes = new PaginatedList<FoodRecipeViewModel>(foodRecipesList, count, pageIndex, pageSize),
            };

            return this.View(viewModel);
        }
    }
}
