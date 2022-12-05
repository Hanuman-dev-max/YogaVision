namespace YogaVision.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.FoodRecipe;
    /// <summary>
    /// Display the latest food recipes
    /// </summary>
    
    public class LatestFoodRecipesViewComponent : ViewComponent
    {
        private readonly IFoodRecipeService foodRecipeService;

        public LatestFoodRecipesViewComponent(IFoodRecipeService foodRecipeService)
        {
            this.foodRecipeService = foodRecipeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? count)
        {
            var viewModel = new FoodRecipesListViewModel
            {
                FoodRecipes = await this.foodRecipeService.GetAllAsync<FoodRecipeViewModel>(count),
            };

            return this.View(viewModel);
        }





    }
}
