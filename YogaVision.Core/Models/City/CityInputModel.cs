

namespace YogaVision.Core.Models.City
{
  
    using System.ComponentModel.DataAnnotations;

    using YogaVision.Common;
    public class CityInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string? Name { get; set; }
    }
}
