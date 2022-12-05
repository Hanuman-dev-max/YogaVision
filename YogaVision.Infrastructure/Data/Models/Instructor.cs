namespace YogaVision.Infrastructure.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
    using YogaVision.Infrastructure.Data.Common.Models;
    public class Instructor : BaseDeletableModel<int>
    {
        public Instructor()
        {
            YogaEvents = new HashSet<YogaEvent>();
        }
        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.FacebookLinkMaxLength)]
        public string FacebookLink { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Nickname { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string ImageUrlFirst { get; set; }

        [Required]
        public string ImageUrlSecond { get; set; }

        [Required]
        public string ImageUrlThird { get; set; }
        public ICollection<YogaEvent> YogaEvents { get; set; }
    }
}
