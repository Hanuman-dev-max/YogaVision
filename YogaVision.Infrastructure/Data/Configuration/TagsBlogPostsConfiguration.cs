namespace YogaVision.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using YogaVision.Infrastructure.Data.Models;
    public class TagsBlogPostsConfiguration : IEntityTypeConfiguration<TagBlogPost>
    {
        public void Configure(EntityTypeBuilder<TagBlogPost> tagsBlogPosts)
        {
            tagsBlogPosts.HasKey(tb => new { tb.TagId, tb.BlogPostId });
        }
    }
}
