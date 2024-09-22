using Microsoft.Extensions.Logging;
using MT.Blog.Common.Extensions;
using MT.Blog.Common.Functional;
using MT.Blog.Common.Functional.Optional;
using MT.Blog.Common.Infrastructure;
using MT.Blog.Posts.Domain.Constants;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;
using MT.Blog.Posts.Infrastructure.Specifications.Posts;

namespace MT.Blog.Posts.Application.Posts.Queries;

internal sealed class GetPostQueryHandler(
    IPostRepository postRepository, 
    ILogger<GetPostQueryHandler> logger) : IQueryHandler<GetPostDetailsQuery, Post>
{
    private readonly IPostRepository _postRepository = postRepository;
    private readonly ILogger<GetPostQueryHandler> _logger = logger;

    public async Task<Result<Post>> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request started: {0}", request.ToString());

        Option<Post> result = await _postRepository.GetAsync(
            GetPostAsNoTrackingSpec.TryCreate(request.PostId), 
            cancellationToken);
        
        _logger.LogInformation("Request was completed. Result is {0}", result.ToString());
        
        return result
            .Map(Result<Post>.Success)
            .Reduce(PostErrors.NotFound);
    }


}
