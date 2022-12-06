namespace YogaVision.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.FoodRecipe;
    /// <summary>
    /// Displays the latest food recipes
    /// </summary>
    public class LatestFoodRecipesViewComponent : ViewComponent
    {
        private readonly IFoodRecipeService foodRecipeService;

        /// <summary>
        /// Constructor for LatestFoodRecipesViewComponent
        /// </summary>
        /// <param name="foodRecipeService">Interface for IFoodRecipeService</param>
        public LatestFoodRecipesViewComponent(IFoodRecipeService foodRecipeService)
        {
            this.foodRecipeService = foodRecipeService;
        }
        /// <summary>
        /// Method which invokes the ViewComponent it RazorViewPage
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
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
