
using YogaVision.Data;
using YogaVision.Infrastructure.Data.Models;

namespace YogaVision.Infrastructure.Data.Seeding.CustomSeeders
{
    public class YogaEventSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.YogaEvents.Any())
            {
                return;
            }

            var YogaEvents = new YogaEvent[]
                {
                    new YogaEvent{
                       Id = Guid.NewGuid().ToString(),
                        DateTime = new DateTime(2022,12,23,10,30,0,0),
                      InstructorId = 1,
                       Description = "Йога с Рада, Айнгар",
                        Seats = 10,
                         StudioId = 3,
                         Duration = "2:00",
                     },
                    new YogaEvent{
                         Id = Guid.NewGuid().ToString(),
                       DateTime = new DateTime(2022,12,24,19,30,0,0),
                      InstructorId = 1,
                       Description = "Йога с Рада, Класическа",
                        Seats = 10,
                         StudioId = 3,
                         Duration = "1:30",
                     },
                    new YogaEvent{
                         Id = Guid.NewGuid().ToString(),
                      DateTime = new DateTime(2022,12,24,19,30,0,0),
                      InstructorId = 2,
                       Description = "Йога с Вивека, Класическа",
                        Seats = 10,
                         StudioId = 1,
                         Duration = "1:30",
                     },
                     new YogaEvent{
                          Id = Guid.NewGuid().ToString(),
                     DateTime = new DateTime(2022,12,25,19,30,0,0),
                      InstructorId = 2,
                       Description = "Йога с Вивека, Aйнгар",
                        Seats = 10,
                         StudioId = 1,
                         Duration = "2:00",
                     },
                      new YogaEvent{
                       Id = Guid.NewGuid().ToString(),
                     DateTime = new DateTime(2022,12,26,9,0,0,0),
                      InstructorId = 3,
                       Description = "Йога с Искра, Aйнгар",
                        Seats = 5,
                         StudioId = 4,
                         Duration = "2:00",
                     },
                      new YogaEvent{
                          Id = Guid.NewGuid().ToString(),
                          DateTime = new DateTime(2022,12,27,18,0,0,0),
                      InstructorId = 3,
                       Description = "Йога с Искра, Aйнгар",
                        Seats = 5,
                         StudioId = 4,
                         Duration = "2:00",
                      },

                          new YogaEvent{
                              Id = Guid.NewGuid().ToString(),
                              DateTime = new DateTime(2022,12,27,19,0,0,0),
                        InstructorId = 2,
                         Description = "Йога със Сита, Класическа",
                            Seats = 12,
                            StudioId = 4,
                            Duration = "2:00",
                     },
                               new YogaEvent{
                                   Id = Guid.NewGuid().ToString(),
                        DateTime = new DateTime(2022,12,29,19,0,0,0),
                        InstructorId = 2,
                         Description = "Йога със Сита, Класическа",
                            Seats = 12,
                            StudioId = 4,
                            Duration = "1:30",
                     },
                        new YogaEvent{
                             Id = Guid.NewGuid().ToString(),
                        DateTime = new DateTime(2022,12,29,19,0,0,0),
                        InstructorId = 4,
                         Description = "Йога със Мукти, Класическа",
                            Seats = 12,
                            StudioId = 4,
                            Duration = "1:30",
                     },
                        new YogaEvent{
                             Id = Guid.NewGuid().ToString(),
                        DateTime = new DateTime(2022,12,28,19,0,0,0),
                        InstructorId = 4,
                         Description = "Йога със Мукти, Класическа",
                            Seats = 12,
                            StudioId = 4,
                            Duration = "1:30",
                     }
                };

            // Need them in particular order
            foreach (var yogaEvent in YogaEvents)
            {
                await dbContext.AddAsync(yogaEvent);
                await dbContext.SaveChangesAsync();
            }
        }




    }
}
