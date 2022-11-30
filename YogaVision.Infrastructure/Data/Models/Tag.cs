namespace YogaVision.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Common.Models;
    public class Tag : BaseDeletableModel<int>
    {
        public Tag()
        {
            BlogPosts = new HashSet<TagBlogPost>();
        }
        [Required]
        public string Name { get; set; }
        public ICollection<TagBlogPost> BlogPosts { get; set; }
    }
}
