using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Blog.Common.Converters;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Database.Configurations;

public sealed class AuthorConfiguration : AuditableConfiguration<Author>, IEntityTypeConfiguration<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(p => p.AuthorId);

        builder.Property(p => p.AuthorId)
            .IsRequired()
            .HasConversion<StronglyTypedIdConverter<AuthorId>>()
            .UseIdentityColumn();

        // TODO: Add complex property that contains first name, last name, etc.

        builder.HasMany(p => p.Posts)
            .WithOne(p => p.Creator)
            .HasForeignKey(p => p.CreatedBy)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Comments)
            .WithOne(p => p.Creator)
            .HasForeignKey(p => p.CreatedBy)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Tags)
            .WithOne(p => p.Creator)
            .HasForeignKey(p => p.CreatedBy)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(DataSeedFunctions.Authors);

        base.Configure(builder);
    }
}
