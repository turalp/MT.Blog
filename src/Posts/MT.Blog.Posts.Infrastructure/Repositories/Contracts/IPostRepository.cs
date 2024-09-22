using Ardalis.Specification;
using MT.Blog.Common.Functional;
using MT.Blog.Common.Functional.Optional;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Repositories.Contracts;

public interface IPostRepository
{
    Task<Post> CreateAsync(Post post, CancellationToken cancellationToken = default);

    Task<Result<Post>> UpdateAsync(Post post, CancellationToken cancellationToken = default);

    Task<Result<Post>> DeleteAsync(Post post, CancellationToken cancellationToken = default);

    Task<Option<Post>> GetAsync(PostId postId, CancellationToken cancellationToken = default);

    Task<Option<Post>> GetAsync(ISingleResultSpecification<Post> specification, CancellationToken cancellationToken = default);

    Task<IEnumerable<Post>> ListAsync(ISpecification<Post> specification, CancellationToken cancellationToken = default);
}
