

using YogaVision.Infrastructure.Data.Common.Mapping;
using YogaVision.Infrastructure.Data.Models;

namespace YogaVision.Core.Models.Instructors
{
    public class InstructorSelectListViewModel : IMapFrom<Instructor>
    {
        public int Id { get; set; }

        public string Nickname { get; set; }
    }
}
