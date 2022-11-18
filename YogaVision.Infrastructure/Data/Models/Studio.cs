namespace YogaVision.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
    using YogaVision.Infrastructure.Data.Common.Models;
    public class Studio : BaseDeletableModel<string>
    {
        public Studio()
        {
            YogaEvents = new HashSet<YogaEvent>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.AddressMaxLength)]
        public string Address { get; set; }

       

        public ICollection<YogaEvent> YogaEvents { get; set; }
    }
}