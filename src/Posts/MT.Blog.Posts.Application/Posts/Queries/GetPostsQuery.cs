using System.Text.Json;
using MT.Blog.Common.Functional.Optional;
using MT.Blog.Common.Infrastructure;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Application.Posts.Queries;

public sealed record class GetPostsQuery(Option<PostId> ParentPostId) : IQuery<IEnumerable<Post>>
{
    public static GetPostsQuery Create(Option<PostId> parentPostId) => new(parentPostId);

    public override string ToString()
    {
        return $"[GetPostsQuery] {JsonSerializer.Serialize(this)}";
    }
}
