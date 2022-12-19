

using System.ComponentModel.DataAnnotations;
using YogaVision.Common;
using YogaVision.Infrastructure.Data.Common.Models;
using YogaVision.Infrastructure.Data.Identity;

namespace YogaVision.Infrastructure.Data.Models
{
    public class Comment : BaseDeletableModel<int>
    {
   
        [MaxLength(GlobalConstants.DataValidations.CommentContentMaxLength)]
        public string Content { get; set; }
        public int BlogPostId  { get; set; }
        public BlogPost BlogPost { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
