
namespace YogaVision.Core.Models.BlogPost
{
    using YogaVision.Core.Models.Tag;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class BlogPostViewModel : IMapFrom<BlogPost>
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? ShortContent { get; set; }

        public string? Content { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }
        public int Likes { get; set; }

       
    }
}