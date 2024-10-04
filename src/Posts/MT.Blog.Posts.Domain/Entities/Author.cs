using System.Diagnostics.CodeAnalysis;
using MT.Blog.Posts.Domain.Entities.Base;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Domain.Entities;

public sealed class Author : Auditable
{
    [SetsRequiredMembers]
    private Author(
        string firstName, 
        string lastName, 
        ICollection<Post>? posts = null,
        ICollection<Comment>? comments = null,
        ICollection<Tag>? tags = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Posts = posts ?? [];
        Comments = comments ?? [];
        Tags = tags ?? [];
    }

    [SetsRequiredMembers]
    private Author(
        string firstName, 
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Posts = [];
        Comments = [];
        Tags = [];
    }

    [SetsRequiredMembers]
    private Author(
        AuthorId authorId,
        string firstName, 
        string lastName)
    {
        AuthorId = authorId;
        FirstName = firstName;
        LastName = lastName;
        Posts = [];
        Comments = [];
        Tags = [];
    }

    public AuthorId AuthorId { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public ICollection<Post> Posts { get; init; }

    public ICollection<Comment> Comments { get; init; }

    public ICollection<Tag> Tags { get; init; }

    public static Author Create(
        string firstName, 
        string lastName, 
        ICollection<Post>? posts = null,
        ICollection<Comment>? comments = null,
        ICollection<Tag>? tags = null) => new(firstName, lastName, posts, comments, tags);

    public static Author Create(
        AuthorId authorId,
        string firstName, 
        string lastName) => new(authorId, firstName, lastName) {
            CreatedAt = DateTime.UtcNow,
            CreatedBy = AuthorId.Create(0)
        };
}
