using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaVision.Infrastructure.Data.Models;

namespace YogaVision.Infrastructure.Data.Configuration
{
    public  class BlogPostApplicationUserConfiguration
    {
        public void Configure(EntityTypeBuilder<BlogPostApplicationUser> blogPostApplicationsUser)
        {
            blogPostApplicationsUser.HasKey(ba => new { ba.BlogPostId, ba.ApplicationUserId });
        }
    }
}
