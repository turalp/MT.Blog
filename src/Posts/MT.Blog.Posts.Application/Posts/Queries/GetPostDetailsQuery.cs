using System.Text.Json;
using MT.Blog.Common.Infrastructure;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Application.Posts.Queries;

internal sealed record class GetPostDetailsQuery(PostId PostId) : IQuery<Post>
{
    public override string ToString() => $"[GetPostQuery] {JsonSerializer.Serialize(this)}";
}
