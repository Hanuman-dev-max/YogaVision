
namespace YogaVision.Core.Models.Instructors
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;

    public class InstructorViewModel : IMapFrom<Instructor>
    {
        public int Id { get; set; }

        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}