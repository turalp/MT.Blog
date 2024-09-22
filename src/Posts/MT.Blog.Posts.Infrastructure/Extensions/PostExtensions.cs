using MT.Blog.Posts.Domain.Entities;

namespace MT.Blog.Posts.Infrastructure.Extensions;

public static class PostExtensions 
{
    public static Post AddComment(this Post post, Comment comment) 
    {
        post.Comments.Add(comment);
        return post;
    } 
}
