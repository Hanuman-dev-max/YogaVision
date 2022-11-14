
namespace YogaVision.Core.Models.YogaEvents
{
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
    using YogaVision.Core.Models.Common;
    public class YogaEventInputModel
    {
        [Required]
        public string StudioId { get; set; }

        [Required]
        public int InstructorId { get; set; }

        [Required]
        [ValidateDateString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]
        public string Date { get; set; }

        [Required]
        [ValidateTimeString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]
        public string Time { get; set; }
        
        [Required]
        [StringLength(
           GlobalConstants.DataValidations.DescriptionMaxLength,
           ErrorMessage = GlobalConstants.ErrorMessages.Description,
           MinimumLength = GlobalConstants.DataValidations.DescriptionMinLength)]
        public string Description { get; set; }
        [Required]
        public string Duration { get; set; }



    }
}
