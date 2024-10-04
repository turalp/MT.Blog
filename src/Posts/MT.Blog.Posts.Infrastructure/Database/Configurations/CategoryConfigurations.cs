using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Blog.Common.Converters;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Database.Configurations;

public sealed class CategoryConfigurations : AuditableConfiguration<Category>, IEntityTypeConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(p => p.CategoryId);

        builder.Property(p => p.CategoryId)
            .IsRequired()
            .HasConversion<StronglyTypedIdConverter<CategoryId>>()
            .UseIdentityColumn();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(32);

            builder.Property(p => p.IconUrl)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(512);

        builder.HasMany(p => p.Posts)
            .WithOne(p => p.Category)
            .IsRequired()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(DataSeedFunctions.Categories);

        base.Configure(builder);
    }
}
