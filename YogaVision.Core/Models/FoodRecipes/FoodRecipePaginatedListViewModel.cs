
namespace YogaVision.Core.Models.FoodRecipes

{
    using YogaVision.Core.Models.Pagination;
    public class FoodRecipePaginatedListViewModel
    {
        public PaginatedList<FoodRecipeViewModel> FoodRecipes { get; set; }
    }
}
