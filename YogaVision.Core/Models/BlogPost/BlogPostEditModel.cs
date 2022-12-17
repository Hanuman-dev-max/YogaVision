

namespace YogaVision.Core.Models.BlogPost
{
    using Microsoft.AspNetCore.Http;
   
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
   
    public class BlogPostEditModel
    {

        public int Id { get; set; }
        [Required]
        [StringLength(
           GlobalConstants.DataValidations.TitleMaxLength,
           ErrorMessage = GlobalConstants.ErrorMessages.Title,
           MinimumLength = GlobalConstants.DataValidations.TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.ContentMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Content,
            MinimumLength = GlobalConstants.DataValidations.ContentMinLength)]
        public string Content { get; set; }

        [Required]
        [StringLength(
           GlobalConstants.DataValidations.ShortContentMaxLength,
           ErrorMessage = GlobalConstants.ErrorMessages.ShortContent,
           MinimumLength = GlobalConstants.DataValidations.ShortContentMinLength)]
        public string ShortContent { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Author,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string Author { get; set; }
        public ICollection<string> Tags { get; set; } = new List<string>();

        
        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }
        public string OldImage { get; set; }

       
    }
}
