using System.Diagnostics.CodeAnalysis;
using MT.Blog.Posts.Domain.Entities.Base;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Domain.Entities;

public sealed class Post : Auditable
{
    /// <summary>
    /// Private constructor to create an instance of object. Cannot be used outside of the class.
    /// </summary>
    /// <param name="title">Specify non-nullable, non-empty title of post.</param>
    /// <param name="description">Specify non-nullable, non-empty description of post.</param>
    /// <param name="categoryId">Specify positive category id of post.</param>
    /// <param name="parentPostId">Specify parent of post if required.</param>
    /// <param name="tags">Collection of tags, if required.</param>
    /// <param name="comments">Collection of related comments, if required.</param>
    /// <param name="subPosts">Collection of subposts, if it's child of another post.</param>
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
        Title = !string.IsNullOrEmpty(title) ? title : throw new ArgumentException("Property cannot be null or empty", nameof(title));
        Description = !string.IsNullOrEmpty(description) ? description : throw new ArgumentException("Property cannot be null or empty", nameof(description));
        CategoryId = categoryId;
        ParentPostId = parentPostId;
        Tags = tags ?? [];
        Comments = comments ?? [];
        SubPosts = subPosts ?? [];
    }

    /// <summary>
    /// Constructor in order to work with Entity Framework Core.
    /// </summary>
    /// <param name="title">Specify non-nullable, non-empty title of post.</param>
    /// <param name="description">Specify non-nullable, non-empty description of post.</param>
    /// <param name="categoryId">Specify positive category id of post.</param>
    /// <param name="parentPostId">Specify parent of post if required.</param>
    [SetsRequiredMembers]
    private Post(
        string title, 
        string description, 
        CategoryId categoryId,
        PostId? parentPostId = null)
    {
        Title = !string.IsNullOrEmpty(title) ? title : throw new ArgumentException("Property cannot be null or empty", nameof(title));
        Description = !string.IsNullOrEmpty(description) ? description : throw new ArgumentException("Property cannot be null or empty", nameof(description));
        CategoryId = categoryId;
        ParentPostId = parentPostId;
        Tags = [];
        Comments = [];
        SubPosts = [];
    }

    public PostId PostId { get; init; }

    public required string Title { get; init; }

    public required string Description { get; init; }

    public PostId? ParentPostId { get; set; }

    public Post? ParentPost { get; init; }

    public CategoryId CategoryId { get; set; }

    public Category? Category { get; init; }

    public ICollection<Tag> Tags { get; init; }

    public ICollection<Comment> Comments { get; init; }

    public ICollection<Post> SubPosts { get; init; }

    /// <summary>
    /// Property that creates an empty post instance. 
    /// Do <b>NOT</b> use unless there are no other ways.
    /// </summary>
    public static Post Empty => Create(string.Empty, string.Empty, CategoryId.Empty);

    /// <summary>
    /// Static method that creates an instance of post entity.
    /// </summary>
    /// <param name="title">Specify non-nullable, non-empty title of post.</param>
    /// <param name="description">Specify non-nullable, non-empty description of post.</param>
    /// <param name="categoryId">Specify positive category id of post.</param>
    /// <param name="parentPostId">Specify parent of post if required.</param>
    /// <param name="tags">Collection of tags, if required.</param>
    /// <param name="comments">Collection of related comments, if required.</param>
    /// <param name="subPosts">Collection of subposts, if it's child of another post.</param>
    /// <returns>Returns a new instance of post entity.</returns>
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
