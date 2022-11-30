namespace YogaVision.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using YogaVision.Infrastructure.Data.Models;
    public class TagBlogPostConfiguration : IEntityTypeConfiguration<TagBlogPost>
    {
        public void Configure(EntityTypeBuilder<TagBlogPost> tagBlogPosts)
        {
            tagBlogPosts.HasKey(tb => new { tb.TagId, tb.BlogPostId });
        }
    }
}
