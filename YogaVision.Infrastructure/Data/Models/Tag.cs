namespace YogaVision.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Common.Models;
    public class Tag : BaseDeletableModel<int>
    {
        public Tag()
        {
            BlogPosts = new HashSet<BlogPost>();
        }
        [Required]
        public string Name { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
