namespace YogaVision.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using YogaVision.Infrastructure.Data.Models;

    public class YogaEventApplicationUserConfiguration : IEntityTypeConfiguration<YogaEventApplicationUser>
    {
        public void Configure(EntityTypeBuilder<YogaEventApplicationUser> yogaEventApplicationsUser)
        {
            yogaEventApplicationsUser.HasKey(ya => new { ya.YogaEventId, ya.ApplicationUserId });
        }
    }
}
