using System.Diagnostics.CodeAnalysis;
using MT.Blog.Posts.Domain.Entities.Base;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Domain.Entities;

public sealed class Category : Auditable
{
    /// <summary>
    /// Constructor in order to work with Entity Framework Core.
    /// </summary>
    /// <param name="name">Specify non-nullable, non-empty name for a category.</param>
    /// <param name="iconUrl">Specify non-nullable, non-empty URL to icon for a category.</param>
    /// <exception cref="ArgumentException">Throws when <paramref name="name"/> or <paramref name="iconUrl"/> is null or emtpy</exception>
    [SetsRequiredMembers]
    private Category(string name, string iconUrl)
    {
        Name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentException("Property cannot be null or empty", nameof(name));
        IconUrl = !string.IsNullOrEmpty(iconUrl) ? iconUrl : throw new ArgumentException("Property cannot be null or empty", nameof(iconUrl));
        Posts = [];
    }

    /// <summary>
    /// Private constructor to create an instance of object. Cannot be used outside of the class.
    /// </summary>
    /// <param name="name">Specify non-nullable, non-empty name for a category.</param>
    /// <param name="iconUrl">Specify non-nullable, non-empty URL to icon for a category.</param>
    /// <param name="posts">Specify collection of posts that category is associated with.</param>
    /// <exception cref="ArgumentException">Throws when <paramref name="name"/> or <paramref name="iconUrl"/> is null or emtpy</exception>
    [SetsRequiredMembers]
    private Category(string name, string iconUrl, ICollection<Post>? posts)
    {
        Name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentException("Property cannot be null or empty", nameof(name));
        IconUrl = !string.IsNullOrEmpty(iconUrl) ? iconUrl : throw new ArgumentException("Property cannot be null or empty", nameof(iconUrl));
        Posts = posts ?? [];
    }

    public CategoryId CategoryId { get; init; }

    public required string Name { get; init; }

    public required string IconUrl { get; init; }

    public ICollection<Post> Posts { get; init; }

    /// <summary>
    /// Static method that creates an instance of category entity.
    /// </summary>
    /// <param name="name">Specify non-nullable, non-empty name for a category.</param>
    /// <param name="iconUrl">Specify non-nullable, non-empty URL to icon for a category.</param>
    /// <param name="posts">Specify collection of posts that category is associated with.</param>
    public static Category Create(string name, string iconUrl, ICollection<Post>? posts = null) 
        => new(name, iconUrl, posts);
}
