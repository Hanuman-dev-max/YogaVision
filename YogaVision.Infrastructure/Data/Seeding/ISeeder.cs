namespace YogaVision.Infrastructure.Data.Seeding
{
    using System;
    using System.Threading.Tasks;
    using YogaVision.Data;
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
