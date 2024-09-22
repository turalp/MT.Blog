namespace MT.Blog.Posts.Infrastructure.Repositories.Contracts;

/// <summary>
/// Contract of Unit of Work pattern that provides two methods.
/// </summary>
public interface IUnitOfWork
{
    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
