using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Blog.Common.Converters;
using MT.Blog.Posts.Domain.Entities.Base;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Database.Configurations;

public class AuditableConfiguration<T> : IEntityTypeConfiguration<T> where T : Auditable
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .Property(p => p.CreatedBy)
            .HasConversion<StronglyTypedIdConverter<AuthorId>>()
            .IsRequired();

        builder
            .Property(p => p.UpdatedBy)
            .HasConversion<StronglyTypedIdConverter<AuthorId>>()
            .IsRequired(false);

        builder
            .Property(p => p.CreatedAt)
            .IsRequired();

        builder
            .Property(p => p.UpdatedBy)
            .IsRequired(false);
    }
}
