using MT.Blog.Common.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Domain.Entities.Base;

/// <summary>
/// Abstract class to define entities that contain audit properties.
/// </summary>
public abstract class Auditable : IEntity
{
    public AuthorId CreatedBy { get; init; }

    public AuthorId? UpdatedBy { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; init; }

    public Author? Creator { get; init; }
}
