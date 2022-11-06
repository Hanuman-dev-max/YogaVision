using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaVision.Common;
using YogaVision.Infrastructure.Data.Common.Models;

namespace YogaVision.Infrastructure.Data.Models
{
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
