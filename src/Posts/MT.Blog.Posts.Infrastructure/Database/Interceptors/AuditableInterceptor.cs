using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MT.Blog.Posts.Domain.Entities.Base;

namespace MT.Blog.Posts.Infrastructure.Database.Interceptors;

internal sealed class AuditableInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, 
        InterceptionResult<int> result)
    {
        if (eventData.Context is not null)
        {
            UpdateAuditableEntities(eventData.Context);
        }

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result, 
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            UpdateAuditableEntities(eventData.Context);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateAuditableEntities(DbContext context)
    {
        DateTime utcNow = DateTime.UtcNow;
        var entities = context.ChangeTracker.Entries<Auditable>().ToList();

        foreach (EntityEntry<Auditable> entry in entities)
        {
            if (entry.State == EntityState.Added)
            {
                SetCurrentPropertyValue(entry, nameof(Auditable.CreatedAt), utcNow);
            }

            if (entry.State == EntityState.Modified)
            {
                SetCurrentPropertyValue(entry, nameof(Auditable.UpdatedAt), utcNow);
            }
        }

        static void SetCurrentPropertyValue(
            EntityEntry entry,
            string propertyName,
            DateTime utcNow) => entry.Property(propertyName).CurrentValue = utcNow;
    }
}
