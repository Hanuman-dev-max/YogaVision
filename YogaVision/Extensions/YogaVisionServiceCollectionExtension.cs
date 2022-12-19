using YogaVision.Core.Contracts;
using YogaVision.Core.Services.Cloadinary;
using YogaVision.Core.Services.DateTimeParser;
using YogaVision.Core.Services;
using YogaVision.Infrastructure.Data.Common;
using YogaVision.Infrastructure.Data.Common.Mapping;
using YogaVision.Models;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension for YogaVisionServiceCollection
    /// </summary>
    public static class YogaVisionServiceCollectionExtension
        {
        /// <summary>
        /// Add Services for the Application 
        /// </summary>
        /// <param name="services">Collection of type IServiceCollection</param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            {
                services.AddControllersWithViews();
                services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
                services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
               

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
                services.AddScoped<ICommentService, CommentService>();
            
                AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            return services;
            }
        }
    }

