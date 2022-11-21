
namespace YogaVision.Core.Models.FoodRecipes

{
    using YogaVision.Core.Models.Pagination;
    public class FoodRecipesPaginatedListViewModel
    {
        public PaginatedList<FoodRecipeViewModel> FoodRecipes { get; set; }
    }
}
