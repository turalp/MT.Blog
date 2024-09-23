using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Blog.Common.Converters;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Database.Configurations;

public sealed class CommentConfiguration : AuditableConfiguration<Comment>, IEntityTypeConfiguration<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(p => p.CommentId);

        builder.Property(p => p.CommentId)
            .IsRequired()
            .HasConversion<StronglyTypedIdConverter<CommentId>>()
            .UseIdentityColumn();

        builder.Property(p => p.Body)
            .IsRequired()
            .HasMaxLength(4000)
            .HasColumnType("nvarchar");

        builder.HasOne(p => p.Parent)
            .WithMany(p => p.SubComments)
            .IsRequired(false)
            .HasForeignKey(p => p.ParentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Post)
            .WithMany(p => p.Comments)
            .IsRequired()
            .HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Creator)
            .WithMany(p => p.Comments)
            .IsRequired()
            .HasForeignKey(p => p.CreatedBy)
            .OnDelete(DeleteBehavior.Cascade);

        base.Configure(builder);
    }
    
}
