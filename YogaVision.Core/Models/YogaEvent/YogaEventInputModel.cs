
namespace YogaVision.Core.Models.YogaEvent
{
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
    using YogaVision.Core.Models.Common;
    public class YogaEventInputModel
    {
        
        public string Id { get; set; }
        [Required]
        public int StudioId { get; set; }

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
           GlobalConstants.DataValidations.EventDescriptionMaxLength,
           ErrorMessage = GlobalConstants.ErrorMessages.YogaEventDescription,
           MinimumLength = GlobalConstants.DataValidations.EventDescriptionMinLength)]
        public string Description { get; set; }
        [Required]
        public string Duration { get; set; }

        [Required]
        [Range(GlobalConstants.DataValidations.SeatMinLength, GlobalConstants.DataValidations.SeatMaxLength)]
        public int Seats { get; set; }



    }
}
