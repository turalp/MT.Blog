using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Infrastructure.Database;

namespace MT.Blog.Posts.Infrastructure.Extensions;

internal static class AuthorExtensions
{
    internal static async Task<Author> AddAsync(this Author author, PostDbContext dbContext, CancellationToken cancellationToken) =>
        (await dbContext.AddAsync(author, cancellationToken)).Entity;

    internal static Author Update(this Author author, PostDbContext dbContext) =>
        dbContext.Authors.Update(author).Entity;

    internal static Author Delete(this Author author, PostDbContext dbContext) =>
        dbContext.Authors.Remove(author).Entity;
}
