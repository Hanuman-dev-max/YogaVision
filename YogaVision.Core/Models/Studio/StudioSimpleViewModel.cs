

namespace YogaVision.Core.Models.Studio
{

    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;

    public class StudioSimpleViewModel : IMapFrom<Studio>
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
