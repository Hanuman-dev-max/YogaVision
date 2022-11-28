namespace YogaVision.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using YogaVision.Infrastructure.Data.Models;

    public class YogaEventApplicationUserConfiguration : IEntityTypeConfiguration<YogaEventApplicationsUser>
    {
        public void Configure(EntityTypeBuilder<YogaEventApplicationsUser> yogaEventApplicationsUser)
        {
            yogaEventApplicationsUser.HasKey(ya => new { ya.YogaEventId, ya.ApplicationUserId });
        }
    }
}
