using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MT.Blog.Common.Extensions;
using MT.Blog.Common.Functional;
using MT.Blog.Common.Functional.Optional;
using MT.Blog.Posts.Domain.Constants;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;
using MT.Blog.Posts.Infrastructure.Database;
using MT.Blog.Posts.Infrastructure.Extensions;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;

namespace MT.Blog.Posts.Infrastructure.Repositories.Concretes;

public sealed class PostRepository(PostDbContext dbContext) : IPostRepository
{
    private readonly PostDbContext _dbContext = dbContext;

    public async Task<Post> CreateAsync(Post post, CancellationToken cancellationToken = default)
        => await post.AddAsync(_dbContext, cancellationToken);

    public async Task<Result<Post>> DeleteAsync(Post post, CancellationToken cancellationToken = default)
        => (await GetAsync(post.PostId, cancellationToken))
            .Map(a => Result<Post>.Success(a.Delete(_dbContext)))
            .Reduce(PostErrors.NotFound);
    public async Task<Option<Post>> GetAsync(PostId postId, CancellationToken cancellationToken = default)
        => await _dbContext.Posts.AsQueryable().SingleOrNoneAsync(a => a.PostId == postId, cancellationToken);

    public async Task<Option<Post>> GetAsync(
        ISingleResultSpecification<Post> specification, 
        CancellationToken cancellationToken = default)
            => await _dbContext.ApplySpecification(specification).SingleOrNoneAsync(cancellationToken);

    public async Task<IEnumerable<Post>> ListAsync(ISpecification<Post> specification, CancellationToken cancellationToken = default)
        => await _dbContext.ApplySpecification(specification).ToArrayAsync(cancellationToken);

    public async Task<Result<Post>> UpdateAsync(Post post, CancellationToken cancellationToken = default)
        => (await GetAsync(post.PostId, cancellationToken))
            .Map(a => Result<Post>.Success(post.Update(_dbContext)))
            .Reduce(PostErrors.NotFound);
}
