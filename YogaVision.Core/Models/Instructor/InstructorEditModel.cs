
namespace YogaVision.Core.Models.Instructor
{
    using Microsoft.AspNetCore.Http;
  
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
    

    public class InstructorEditModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.DescriptionMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Description,
            MinimumLength = GlobalConstants.DataValidations.DescriptionMinLength)]
        public string? Description { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.FacebookLinkMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Facebook,
            MinimumLength = GlobalConstants.DataValidations.FacebookLinkMinLength)]
        public string? FacebookLink { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string? Nickname { get; set; }

       
        [DataType(DataType.Upload)]
      
        public IFormFile? Image { get; set; }

       
        [DataType(DataType.Upload)]
       
        public IFormFile? ImageFirst { get; set; }

      
        [DataType(DataType.Upload)]
        
        public IFormFile? ImageSecond { get; set; }

       
        [DataType(DataType.Upload)]
      
        public IFormFile? ImageThird { get; set; }

        public string? OldImage { get; set; }
        public string? OldImageFirst { get; set; }
        public string? OldImageSecond { get; set; }
        public string? OldImageThird { get; set; }



    }
}
