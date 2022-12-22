namespace YogaVision.Core.Models.City
{
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;

    public class CityEditModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string? Name { get; set; }

    }
}
