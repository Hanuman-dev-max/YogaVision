namespace YogaVision.Core.Models.Studio
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
    using YogaVision.Core.Models.Common;
    public class StudioInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.AddressMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Address,
            MinimumLength = GlobalConstants.DataValidations.AddressMinLength)]
        public string Address { get; set; }

        [DataType(DataType.Upload)]
        [ValidateImageFile(ErrorMessage = GlobalConstants.ErrorMessages.Image)]
        public IFormFile Image { get; set; }
    }
}
