
namespace YogaVision.Core.Models.TagBlogPost
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class TagBlogPostViewModel :IMapFrom<TagBlogPost>
    {
        public int TagId { get; set; }
        public string TagName { get; set;}
    }
}
