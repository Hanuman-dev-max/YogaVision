namespace YogaVision.Core.Models.Tag
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class TagViewModel : IMapFrom<Tag>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
