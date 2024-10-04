using System.Diagnostics.CodeAnalysis;
using MT.Blog.Posts.Domain.Entities.Base;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Domain.Entities;

public sealed class Comment : Auditable
{
    [SetsRequiredMembers]
    private Comment(string body, CommentId? parentCommentId, PostId postId, Post? post = null, ICollection<Comment>? subComments = null) 
    {
        Body = !string.IsNullOrEmpty(body) ? body : throw new ArgumentException("Property cannot be null or empty", nameof(body));
        PostId = postId.Value > 0 ? postId : throw new ArgumentException("Primary key must be greater than zero", nameof(postId));
        ParentId = !parentCommentId.HasValue || parentCommentId?.Value > 0 ? parentCommentId : throw new ArgumentException("Primary key must be greater than zero", nameof(parentCommentId));
        SubComments = subComments ?? [];
        Post = post;
    }

    [SetsRequiredMembers]
    private Comment(string body, PostId postId) 
    {
        Body = !string.IsNullOrEmpty(body) ? body : throw new ArgumentException("Property cannot be null or empty", nameof(body));
        PostId = postId.Value > 0 ? postId : throw new ArgumentException("Primary key must be greater than zero", nameof(postId));
        SubComments = [];
        Post = Post.Empty;
    }

    [SetsRequiredMembers]
    private Comment(CommentId commentId, string body, PostId postId) 
    {
        CommentId = commentId.Value > 0 ? commentId : throw new ArgumentException("Primary key must be greater than zero", nameof(commentId));
        Body = !string.IsNullOrEmpty(body) ? body : throw new ArgumentException("Property cannot be null or empty", nameof(body));
        PostId = postId.Value > 0 ? postId : throw new ArgumentException("Primary key must be greater than zero", nameof(postId));
        SubComments = [];
        Post = Post.Empty;
    }

    public CommentId CommentId { get; init; }

    public required string Body { get; init; }

    public CommentId? ParentId { get; init; }

    public Comment? Parent { get; init; }

    public PostId PostId { get; init; }

    public Post? Post { get; init; }

    public ICollection<Comment> SubComments { get; init; }

    public static Comment Create(string body, PostId postId, CommentId? parentCommentId, Post? post = null, ICollection<Comment>? subComments = null) => 
        new(body, parentCommentId, postId, post, subComments);

    public static Comment Create(CommentId commentId, string body, PostId postId) => 
        new(commentId, body, postId);
}
