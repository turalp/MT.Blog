using System.Diagnostics.CodeAnalysis;
using MT.Blog.Posts.Domain.Entities.Base;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Domain.Entities;

public sealed class Tag : Auditable
{
    [SetsRequiredMembers]
    private Tag(string name, ICollection<Post>? posts = null)
    {
        Name = name;
        Posts = posts ?? [];
    }

    [SetsRequiredMembers]
    private Tag(string name)
    {
        Name = name;
        Posts = [];
    }

    public TagId TagId { get; init; }

    public required string Name { get; init; }

    public ICollection<Post> Posts { get; init; }

    public static Tag Create(string name, ICollection<Post>? posts = null) => new(name, posts);
}
