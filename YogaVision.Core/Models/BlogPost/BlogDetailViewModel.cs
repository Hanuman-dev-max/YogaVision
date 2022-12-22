using System.ComponentModel.DataAnnotations;
using YogaVision.Common;
using YogaVision.Core.Models.Comment;
using static YogaVision.Common.GlobalConstants;

namespace YogaVision.Core.Models.BlogPost
{
   
    public class BlogDetailViewModel
    {
        public BlogPostViewModel blog { get; set; } = new BlogPostViewModel();
        public ICollection<string> tags { get; set; } = new List<string>();
        public IEnumerable<CommentViewModel> comments { get; set; } = new List<CommentViewModel>();
        [Required]
        [StringLength(
           GlobalConstants.DataValidations.CommentMaxLength,
           ErrorMessage = GlobalConstants.ErrorMessages.Comment,
           MinimumLength = GlobalConstants.DataValidations.CommentMinLength)]
        public string? UserComment { get; set; }

    }
}
