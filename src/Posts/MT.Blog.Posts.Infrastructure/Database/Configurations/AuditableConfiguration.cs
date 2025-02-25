using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MT.Blog.Posts.Domain.Entities.Base;

namespace MT.Blog.Posts.Infrastructure.Database.Configurations;

public class AuditableConfiguration<T> : IEntityTypeConfiguration<T> where T : Auditable
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .Property(p => p.CreatedBy)
            .IsRequired();

        builder
            .Property(p => p.UpdatedBy)
            .IsRequired(false);

        builder
            .Property(p => p.CreatedAt)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder
            .Property(p => p.UpdatedBy)
            .ValueGeneratedOnUpdate()
            .IsRequired(false);
    }
}
