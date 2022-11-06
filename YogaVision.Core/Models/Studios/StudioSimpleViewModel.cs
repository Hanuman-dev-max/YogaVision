

namespace YogaVision.Core.Models.Studios
{

    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;

    public class StudioSimpleViewModel : IMapFrom<Studio>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
