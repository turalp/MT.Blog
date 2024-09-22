using MT.Blog.Posts.Infrastructure.Database;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;

namespace MT.Blog.Posts.Infrastructure.Repositories.Concretes;

/// <summary>
/// Concrete implementation of Unit of Work pattern.
/// </summary>
/// <param name="dbContext">Database context that works at "posts" schema.</param>
internal sealed class UnitOfWork(PostDbContext dbContext) : IUnitOfWork
{
    private readonly PostDbContext _dbContext = dbContext;

    public int SaveChanges() => _dbContext.SaveChanges();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => 
        await _dbContext.SaveChangesAsync(cancellationToken);
}
