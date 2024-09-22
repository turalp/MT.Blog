using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Infrastructure.Database;

namespace MT.Blog.Posts.Infrastructure.Extensions;

public static class PostExtensions
{
    internal static async Task<Post> AddAsync(this Post post, PostDbContext dbContext, CancellationToken cancellationToken) 
        => (await dbContext.Posts.AddAsync(post, cancellationToken)).Entity;

    internal static Post Update(this Post post, PostDbContext dbContext) 
        => dbContext.Posts.Update(post).Entity;

    internal static Post Delete(this Post post, PostDbContext dbContext) 
        => dbContext.Posts.Remove(post).Entity;
}
