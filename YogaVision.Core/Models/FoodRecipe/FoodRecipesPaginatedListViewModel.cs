
namespace YogaVision.Core.Models.FoodRecipe

{
    using YogaVision.Core.Models.Pagination;
    public class FoodRecipesPaginatedListViewModel
    {
        public PaginatedList<FoodRecipeViewModel> FirstRowFoodRecipes { get; set; }
        public PaginatedList<FoodRecipeViewModel> SecondRowFoodRecipes { get; set; }

    }
}

