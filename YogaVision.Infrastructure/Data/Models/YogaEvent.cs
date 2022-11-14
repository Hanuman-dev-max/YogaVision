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
    public class YogaEvent: BaseDeletableModel<string>
    {
        [Required]
        [MaxLength(GlobalConstants.DataValidations.DescriptionMaxLength)]
        public string Description { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        
        [Required]
        public string Duration { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public string StudioId { get; set; }
        public Studio Studio { get; set; }
    }
}
