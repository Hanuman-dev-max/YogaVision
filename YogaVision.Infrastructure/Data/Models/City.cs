namespace YogaVision.Infrastructure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Common;
    using YogaVision.Infrastructure.Data.Common.Models;
    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Studios = new HashSet<Studio>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Studio> Studios { get; set; }
    }
}
