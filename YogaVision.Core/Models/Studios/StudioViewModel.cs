

namespace YogaVision.Core.Models.Studios
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class StudioViewModel : IMapFrom<Studio>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string CityName { get; set; }

        public string Address { get; set; }

    }
}