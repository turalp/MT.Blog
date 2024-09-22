using Ardalis.Specification;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Specifications.Posts;

public sealed class GetPostAsNoTrackingSpec : SingleResultSpecification<Post>, ISingleResultSpecification<Post>
{
    private GetPostAsNoTrackingSpec(PostId postId) => 
        Query
            .AsNoTracking()
            .AsSplitQuery()
            .Where(p => p.PostId == postId)
            .Include(p => p.Comments)
            .Include(p => p.Tags)
            .Include(p => p.CreatedBy);
    
    public static GetPostAsNoTrackingSpec TryCreate(PostId postId) 
        => postId.Value > 1 ? 
            new(postId) : 
            throw new ArgumentException("Primary key must be greater than zero.", nameof(postId)); 
}
