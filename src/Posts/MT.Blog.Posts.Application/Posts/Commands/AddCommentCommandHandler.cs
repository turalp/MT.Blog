using Microsoft.Extensions.Logging;
using MT.Blog.Common.Extensions;
using MT.Blog.Common.Functional;
using MT.Blog.Common.Functional.Optional;
using MT.Blog.Common.Infrastructure;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Infrastructure.Extensions;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;

namespace MT.Blog.Posts.Application.Posts.Commands;

public sealed class AddCommentCommandHandler(
    IPostRepository postRepository, 
    ILogger<AddCommentCommandHandler> logger) : ICommandHandler<AddCommentCommand, Comment>
{
    private readonly IPostRepository _postRepository = postRepository;
    
    private readonly ILogger<AddCommentCommandHandler> _logger = logger;

    public async Task<Result<Comment>> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request started: {0}", request.ToString());

        Option<Post> post = await _postRepository.GetAsync(request.Comment.PostId);
        Result<Post> result = await _postRepository.UpdateAsync(
            post
                .Map(p => p.AddComment(request.Comment))
                .Reduce(Post.Empty), 
            cancellationToken);

        _logger.LogInformation("Request was completed. Result is {0}", result.ToString());
        
        return result.IsSuccess ? request.Comment : result.Error;
    }
}
