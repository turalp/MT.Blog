using System.Text.Json;
using MT.Blog.Common.Infrastructure;
using MT.Blog.Posts.Domain.Entities;

namespace MT.Blog.Posts.Application.Posts.Commands;

public sealed record class AddCommentCommand(Comment Comment) : ICommand<Comment> 
{
    public override string ToString() => $"[AddCommentCommand] {JsonSerializer.Serialize(this)}";
}
