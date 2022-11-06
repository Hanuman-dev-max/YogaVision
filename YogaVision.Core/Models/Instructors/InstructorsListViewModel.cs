using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaVision.Core.Models.BlogPosts;

namespace YogaVision.Core.Models.Instructors
{
    public class InstructorsListViewModel
    {
        public IEnumerable<InstructorViewModel> Instructors { get; set; }

    }
}
