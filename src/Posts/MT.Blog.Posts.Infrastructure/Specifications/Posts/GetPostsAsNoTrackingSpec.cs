using Ardalis.Specification;
using MT.Blog.Posts.Domain.Entities;

namespace MT.Blog.Posts.Infrastructure.Specifications.Posts;

public sealed class GetPostsAsNoTrackingSpec : Specification<Post>, ISpecification<Post>
{
    private GetPostsAsNoTrackingSpec() => Query.AsNoTracking();

    public static GetPostsAsNoTrackingSpec Create() => new();
}
