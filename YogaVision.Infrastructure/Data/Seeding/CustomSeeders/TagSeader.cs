

using YogaVision.Data;
using YogaVision.Infrastructure.Data.Models;

namespace YogaVision.Infrastructure.Data.Seeding.CustomSeeders
{
    public class TagSeader
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Tags.Any())
            {
                return;
            }

            var cities = new Tag[]
                {
                    new Tag // Id = 1
                    {
                        Name = "хараш",
                    },
                    new Tag // Id = 2
                    {
                        Name = "истина",
                    },
                    new Tag // Id = 3
                    {
                        Name = "любов",
                    },
                     new Tag // Id = 4
                    {
                        Name = "дух",
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
