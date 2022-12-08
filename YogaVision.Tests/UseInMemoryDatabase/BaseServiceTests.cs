using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YogaVision.Core.Contracts;
using YogaVision.Core.Services;
using YogaVision.Data;
using YogaVision.Infrastructure.Data.Common;
using YogaVision.Infrastructure.Data.Common.Mapping;
using YogaVision.Models;

namespace YogaVision.Tests.UseInMemoryDatabase
{
    public abstract class BaseServiceTests : IDisposable
    {
        protected BaseServiceTests()
        {
            var services = this.SetServices();

            this.ServiceProvider = services.BuildServiceProvider();
            this.DbContext = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        protected IServiceProvider ServiceProvider { get; set; }

        protected ApplicationDbContext DbContext { get; set; }

        public void Dispose()
        {
            this.DbContext.Database.EnsureDeleted();
            this.SetServices();
        }

        private ServiceCollection SetServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Application services
           
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IStudioService, StudioService>();
            services.AddTransient<IInstructorService, InstructorService>();
            services.AddTransient<IBlogPostService, BlogPostService>();
            services.AddTransient<IFoodRecipeService, FoodRecipeService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<ITagBlogPostService, TagBlogPostService>();

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            return services;
        }
    }
}
