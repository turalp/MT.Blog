using System.Text.Json;
using MT.Blog.Common.Infrastructure;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Application.Posts.Queries;

public sealed record class GetPostDetailsQuery(PostId PostId) : IQuery<Post>
{
    public static GetPostDetailsQuery TryCreate(PostId postId) => 
        postId.Value > 1 ?
            new(postId) :
            throw new ArgumentException("Primary key must be greater than zero.", nameof(postId));

    public override string ToString() => $"[GetPostQuery] {JsonSerializer.Serialize(this)}";
}
