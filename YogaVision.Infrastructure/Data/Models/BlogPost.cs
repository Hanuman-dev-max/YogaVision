

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
            Tags = new HashSet<Tag>();
        }
        [Required]
        [MaxLength(GlobalConstants.DataValidations.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.ShortContentMaxLength)]
        public string ShortContent { get; set; }

        // BlogPost can be created only in the Admin Dashboard
        // so the Author is not a User, just a string for name
        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Author { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
