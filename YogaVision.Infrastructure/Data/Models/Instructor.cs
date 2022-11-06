

namespace YogaVision.Infrastructure.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
    using YogaVision.Infrastructure.Data.Common.Models;
    public class Instructor : BaseDeletableModel<int>
    {
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
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Nickname { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
