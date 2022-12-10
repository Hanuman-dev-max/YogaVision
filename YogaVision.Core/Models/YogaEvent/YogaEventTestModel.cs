



namespace YogaVision.Core.Models.YogaEvent
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class YogaEventTestModel : IMapFrom<YogaEvent>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Duration { get; set; }
        public int Seats { get; set; }



    }
}
