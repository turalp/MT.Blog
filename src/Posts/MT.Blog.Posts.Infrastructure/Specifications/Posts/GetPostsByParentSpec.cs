using Ardalis.Specification;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Specifications.Posts;

public sealed class GetPostsByParentSpec : Specification<Post>, ISpecification<Post>
{
    private GetPostsByParentSpec(PostId parentPostId) => 
        Query
            .AsNoTracking()
            .Include(p => p.SubPosts)
            .Where(p => p.ParentPostId == parentPostId);

    public static GetPostsByParentSpec TryCreate(PostId parentPostId) 
        => parentPostId.Value > 1 ? new(parentPostId) : throw new ArgumentException("Primary key must be greater than zero.");
}
