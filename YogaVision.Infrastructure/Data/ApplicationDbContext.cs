using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YogaVision.Infrastructure.Data.Identity;
using YogaVision.Infrastructure.Data.Models;

namespace YogaVision.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<FoodRecipe> FoodRecipes { get; set; }
        public DbSet<YogaEvent> YogaEvents { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}