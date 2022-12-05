namespace YogaVision.Infrastructure.Data.Seeding.CustomSeeders
{
    using YogaVision.Data;
    using YogaVision.Infrastructure.Data.Models;
    public class StudiosSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Studios.Any())
            {
                return;
            }

            var studios = new Studio[]
                {
                    new Studio //id 1
                    {
                        
                        Name = "Еделрайз",
                        CityId = 1,
                         Address = "Комплекс България, ет.2, пл.Свобода 19",
                          ImageUrl ="https://res.cloudinary.com/dig1baxyv/image/upload/v1669183884/YogaVision/edelrise_lqlhpx.webp",
                    },
                    new Studio //id 2
                    {
                       
                        Name = "Отпускане",
                        CityId = 2,
                        Address = "ул. Златовръх 51 Б",
                         ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1669184023/YogaVision/otpuskane_miv3as.jpg"
                    },
                    new Studio //id 3
                    {
                       
                        Name = "Холистичен Център Слънце",
                         CityId = 4,
                          Address = "ул. Академик Иширков 10 ет.4",
                           ImageUrl ="https://res.cloudinary.com/dig1baxyv/image/upload/v1669235572/YogaVision/Lovech_f63urz.jpg",
                    },
                     new Studio // id 4
                    {
                        
                        Name = "Yoga.Iskra",
                        CityId = 3,
                        Address ="Белясковец",
                        ImageUrl ="https://res.cloudinary.com/dig1baxyv/image/upload/v1669185464/YogaVision/Beliaskovets_vnaimn.jpg",
                    },
                };

            // Need them in particular order
            foreach (var studio in studios)
            {
                await dbContext.AddAsync(studio);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
