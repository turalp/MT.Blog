using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Blog.Common.Converters;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Database.Configurations;

public sealed class PostConfiguration : AuditableConfiguration<Post>, IEntityTypeConfiguration<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.PostId);

        builder.Property(p => p.PostId)
            .IsRequired()
            .HasConversion<StronglyTypedIdConverter<PostId>>()
            .UseIdentityColumn();

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(512)
            .HasColumnType("nvarchar");
        
        builder.HasMany(p => p.Tags)
            .WithMany(p => p.Posts);
        
        builder.HasMany(p => p.Comments)
            .WithOne(p => p.Post)
            .HasForeignKey(p => p.PostId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.SubPosts)
            .WithOne(p => p.ParentPost)
            .HasForeignKey(p => p.ParentPostId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(p => p.Creator)
            .WithMany(p => p.Posts)
            .IsRequired()
            .HasForeignKey(p => p.CreatedBy)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Updator)
            .WithMany(p => p.Posts)
            .IsRequired(false)
            .HasForeignKey(p => p.UpdatedBy)
            .OnDelete(DeleteBehavior.SetNull);

        base.Configure(builder);
    }
}
