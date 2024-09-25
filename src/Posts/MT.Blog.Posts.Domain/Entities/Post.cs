using System.Diagnostics.CodeAnalysis;
using MT.Blog.Posts.Domain.Entities.Base;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Domain.Entities;

public sealed class Post : Auditable
{
    [SetsRequiredMembers]
    private Post(
        string title, 
        string description, 
        CategoryId categoryId,
        PostId? parentPostId = null, 
        ICollection<Tag>? tags = null,
        ICollection<Comment>? comments = null,
        ICollection<Post>? subPosts = null)
    {
        Title = title;
        Description = description;
        CategoryId = categoryId;
        ParentPostId = parentPostId;
        Tags = tags ?? [];
        Comments = comments ?? [];
        SubPosts = subPosts ?? [];
    }

    [SetsRequiredMembers]
    private Post(
        string title, 
        string description, 
        CategoryId categoryId,
        PostId? parentPostId = null)
    {
        Title = title;
        Description = description;
        CategoryId = categoryId;
        ParentPostId = parentPostId;
        Tags = [];
        Comments = [];
        SubPosts = [];
    }

    public PostId PostId { get; init; }

    public required string Title { get; init; }

    public required string Description { get; init; }

    public PostId? ParentPostId { get; init; }

    public Post? ParentPost { get; init; }

    public CategoryId CategoryId { get; init; }

    public ICollection<Tag> Tags { get; init; }

    public ICollection<Comment> Comments { get; init; }

    public ICollection<Post> SubPosts { get; init; }

    public Category? Category { get; init; }

    public static Post Empty => Create(string.Empty, string.Empty, CategoryId.Empty);

    public static Post Create(
        string title, 
        string description, 
        CategoryId categoryId,
        PostId? parentPostId = null, 
        ICollection<Tag>? tags = null,
        ICollection<Comment>? comments = null,
        ICollection<Post>? subPosts = null) => 
            new(title, description, categoryId, parentPostId, tags, comments, subPosts);
}
