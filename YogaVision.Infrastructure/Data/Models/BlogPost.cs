

namespace YogaVision.Infrastructure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
    using YogaVision.Infrastructure.Data.Common.Models;
    
    public class BlogPost : BaseDeletableModel<int>
    {
     
        public BlogPost()
        {
            Tags = new HashSet<TagBlogPost>();
        }
        
        [Required]
        [MaxLength(GlobalConstants.DataValidations.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.DataValidations.ContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.DataValidations.ShortContentMaxLength)]
        public string ShortContent { get; set; } = null!;

       
        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public ICollection<TagBlogPost> Tags{ get; set; }


    }
}
