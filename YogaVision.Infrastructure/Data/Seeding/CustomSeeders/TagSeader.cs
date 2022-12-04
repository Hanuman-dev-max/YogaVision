

using YogaVision.Data;
using YogaVision.Infrastructure.Data.Models;

namespace YogaVision.Infrastructure.Data.Seeding.CustomSeeders
{
    public class TagSeader :ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Tags.Any())
            {
                return;
            }

            var tags = new Tag[]
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
                    new Tag // Id = 5
                    {
                        Name = "мъдрост",
                    },
                    new Tag // Id = 6
                    {
                        Name = "омкар",
                    },
                    new Tag // Id = 7
                    {
                        Name = "медитация",
                    },
                    new Tag // Id = 8
                    {
                        Name = "кану",
                    },
                     new Tag // Id = 9
                    {
                        Name = "отдаденост",
                    },
                      new Tag // Id = 10
                    {
                        Name = "посветеност",
                    },
                       new Tag // Id = 11
                    {
                        Name = "себепознание",
                    },
                    new Tag // Id = 12
                    {
                        Name = "астрология",
                    },
                     new Tag // Id = 13
                    {
                        Name = "покана",
                    },
                    new Tag // Id = 14
                    {
                        Name = "балтова",
                    },
                    new Tag // Id = 15
                    {
                        Name = "орешков",
                    },
                    new Tag // Id = 16
                    {
                        Name = "интервю",
                    },


                };

            // Need them in particular order
            foreach (var tag in tags)
            {
                await dbContext.AddAsync(tag);
                await dbContext.SaveChangesAsync();
            }
        }


    }
}