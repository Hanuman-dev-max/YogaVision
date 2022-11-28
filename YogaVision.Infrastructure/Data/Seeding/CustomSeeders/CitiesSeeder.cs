

namespace YogaVision.Infrastructure.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using YogaVision.Data;
    using YogaVision.Infrastructure.Data.Models;
    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            var cities = new City[]
                {
                    new City // Id = 1
                    {
                        Name = "Плевен",
                    },
                    new City // Id = 2
                    {
                        Name = "София",
                    },
                    new City // Id = 3
                    {
                        Name = "Велико Търново",
                    },
                     new City // Id = 4
                    {
                        Name = "Ловеч",
                    },
                };

            // Need them in particular order
            foreach (var city in cities)
            {
                await dbContext.AddAsync(city);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
