namespace YogaVision.Core.Models.Instructor
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;

    public class InstructorViewModel : IMapFrom<Instructor>
    {
        public int Id { get; set; }

        public string? NickName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Description { get; set; }

        public string? FacebookLink { get; set; }
        public string? ImageUrl { get; set; }

        public string? ImageUrlFirst { get; set; }

        public string? ImageUrlSecond { get; set; }

        public string? ImageUrlThird { get; set; }

        public DateTime? CreatedOn { get; set; }

    }
}