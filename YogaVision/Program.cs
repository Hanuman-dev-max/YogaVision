using CloudinaryDotNet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using YogaVision.Common;
using YogaVision.Core.Contracts;
using YogaVision.Core.Services.Cloadinary;
using YogaVision.Core.Services;
using YogaVision.Data;
using YogaVision.Infrastructure.Data.Identity;
using YogaVision.Infrastructure.Data.Common;
using YogaVision.Infrastructure.Data.Common.Mapping;
using YogaVision.Models;
using System.Reflection;
using YogaVision.Core.Services.DateTimeParser;
using YogaVision.Infrastructure.Data.Seeding;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6; })
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));


Cloudinary cloudinary = new Cloudinary(new Account("dig1baxyv",
               "138278377333434", "Nn_Wy3hy1-lSym_M-toCWwY2jHY"));
builder.Services.AddSingleton(cloudinary);

// Application services

builder.Services.AddScoped<IBlogPostsService, BlogPostsService>();
builder.Services.AddScoped<ICitiesService, CitiesService>();
builder.Services.AddScoped<IStudiosService, StudiosService>();
builder.Services.AddScoped<IFoodRecipesService, FoodRecipesService>();
builder.Services.AddScoped<IInstructorsService, InstructorsService>();
builder.Services.AddScoped<IYogaEventsService, YogaEventsService>();
builder.Services.AddScoped<IYogaEventApplicationUserService, YogaEventApplicationUserService>();
builder.Services.AddScoped<IDateTimeParserService, DateTimeParserService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ITagBlogPostsService, TagBlogPostsService>();


builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

var app = builder.Build();

AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);



using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (app.Environment.IsDevelopment())
    {
        dbContext.Database.Migrate();
    }

    new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
