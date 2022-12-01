using CloudinaryDotNet;
using YogaVision.Core.Contracts;
using YogaVision.Core.Services.Cloadinary;
using YogaVision.Core.Services.DateTimeParser;
using YogaVision.Core.Services;
using YogaVision.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
        public static class YogaVisionServiceCollectionExtension
        {
            public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            {
                services.AddControllersWithViews();
                services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
                services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
                Cloudinary cloudinary = new Cloudinary(new Account("dig1baxyv",
                       "138278377333434", "Nn_Wy3hy1-lSym_M-toCWwY2jHY"));
                services.AddSingleton(cloudinary);

            // Application services

                services.AddScoped<IBlogPostService, BlogPostService>();
                services.AddScoped<ICityService, CityService>();
                services.AddScoped<IStudioService, StudioService>();
                services.AddScoped<IFoodRecipeService, FoodRecipeService>();
                services.AddScoped<IInstructorService, InstructorService>();
                services.AddScoped<IYogaEventService, YogaEventService>();
                services.AddScoped<IYogaEventApplicationUserService, YogaEventApplicationUserService>();
                services.AddScoped<IDateTimeParserService, DateTimeParserService>();
                services.AddScoped<ITagService, TagService>();
                services.AddScoped<ITagBlogPostService, TagBlogPostService>();
                services.AddScoped<ICloudinaryService, CloudinaryService>();

            return services;
            }
        }
    }

