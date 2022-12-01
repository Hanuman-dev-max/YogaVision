namespace YogaVision.Core.Models.Instructor
{

    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class InstructorSelectListViewModel : IMapFrom<Instructor>
    {
        public int Id { get; set; }

        public string Nickname { get; set; }
    }
}
