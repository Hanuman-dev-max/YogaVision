using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaVision.Infrastructure.Data.Common.Mapping;
using YogaVision.Infrastructure.Data.Models;

namespace YogaVision.Core.Models.Cities
{
    public class CityViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StudiosCount { get; set; }
    }
}
