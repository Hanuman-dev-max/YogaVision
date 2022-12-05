

namespace YogaVision.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
    using YogaVision.Infrastructure.Data.Common.Models;
    public class FoodRecipe : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.DataValidations.TitleMaxLength)]
        public string Title { get; set; }
        [Required]
        [MaxLength(GlobalConstants.DataValidations.RequiredProductsMaxLength)]
        public string  RequiredProducts { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.FoodContentMaxLength)]
        public string Content { get; set; }

       
        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Author { get; set; }

        [Required]
        public string ImageUrl { get; set; }

    }
}
