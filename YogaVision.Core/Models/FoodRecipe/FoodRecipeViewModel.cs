namespace YogaVision.Core.Models.FoodRecipe
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class FoodRecipeViewModel : IMapFrom<FoodRecipe>
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? RequiredProducts { get; set; }

        public string? Content { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}