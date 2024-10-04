using System.Diagnostics.CodeAnalysis;
using MT.Blog.Posts.Domain.Entities.Base;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Domain.Entities;

public sealed class Tag : Auditable
{
    [SetsRequiredMembers]
    private Tag(string name, ICollection<Post>? posts = null)
    {
        Name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentException("Property cannot be null or empty", nameof(name));
        Posts = posts ?? [];
    }

    [SetsRequiredMembers]
    private Tag(string name)
    {
        Name = name;
        Posts = [];
    }

    [SetsRequiredMembers]
    private Tag(TagId tagId, string name)
    {
        TagId = tagId.Value > 0 ? tagId : throw new ArgumentException("Primary key must be greater than zero", nameof(tagId));
        Name = name;
        Posts = [];
    }

    public TagId TagId { get; init; }

    public required string Name { get; init; }

    public ICollection<Post> Posts { get; init; }

    public static Tag Create(string name, ICollection<Post>? posts = null) => new(name, posts);

    public static Tag Create(TagId tagId, string name) => new(tagId, name);
}
