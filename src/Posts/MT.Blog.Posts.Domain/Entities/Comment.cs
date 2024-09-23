using System.Diagnostics.CodeAnalysis;
using MT.Blog.Posts.Domain.Entities.Base;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Domain.Entities;

public sealed class Comment : Auditable
{
    [SetsRequiredMembers]
    private Comment(string body, CommentId? parentCommentId, PostId postId, Post? post = null, ICollection<Comment>? subComments = null) 
    {
        Body = body;
        PostId = postId;
        ParentId = parentCommentId;
        SubComments = subComments ?? [];
        Post = post;
    }

    [SetsRequiredMembers]
    private Comment(string body, PostId postId) 
    {
        Body = body;
        PostId = postId;
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
}
