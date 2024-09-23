using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Blog.Common.Converters;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Database.Configurations;

public sealed class TagConfiguration : AuditableConfiguration<Tag>, IEntityTypeConfiguration<Tag>
{
    public override void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(p => p.TagId);

        builder.Property(p => p.TagId)
            .IsRequired()
            .HasConversion<StronglyTypedIdConverter<TagId>>()
            .UseIdentityColumn();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(128)
            .HasColumnType("nvarchar");

        builder.HasMany(p => p.Posts)
            .WithMany(p => p.Tags);

        builder.HasOne(p => p.Creator)
            .WithMany(p => p.Tags)
            .IsRequired()
            .HasForeignKey(p => p.CreatedBy)
            .OnDelete(DeleteBehavior.Cascade);

        base.Configure(builder);
    }
}
