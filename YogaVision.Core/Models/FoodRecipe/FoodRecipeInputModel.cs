namespace YogaVision.Core.Models.FoodRecipe
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
    using YogaVision.Core.Models.Common;
    public class FoodRecipeInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.TitleMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Title,
            MinimumLength = GlobalConstants.DataValidations.TitleMinLength)]
        public string? Title { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.RequiredProductsMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Content,
            MinimumLength = GlobalConstants.DataValidations.RequiredProductsMinLength)]
        public string? RequiredProducts { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.FoodContentMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Content,
            MinimumLength = GlobalConstants.DataValidations.FoodContentMinLength)]
        public string? Content { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Author,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string? Author { get; set; }

       
        [DataType(DataType.Upload)]
        [ValidateImageFile(ErrorMessage = GlobalConstants.ErrorMessages.Image)]
        public IFormFile? Image { get; set; }
    }
}
