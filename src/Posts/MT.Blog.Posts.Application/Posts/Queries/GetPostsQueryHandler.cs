using Ardalis.Specification;
using Microsoft.Extensions.Logging;
using MT.Blog.Common.Extensions;
using MT.Blog.Common.Functional;
using MT.Blog.Common.Infrastructure;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;
using MT.Blog.Posts.Infrastructure.Specifications.Posts;

namespace MT.Blog.Posts.Application.Posts.Queries;

internal sealed class GetPostsQueryHandler(
    IPostRepository postRepository, 
    ILogger<GetPostsQueryHandler> logger) : IQueryHandler<GetPostsQuery, IEnumerable<Post>>
{
    private readonly IPostRepository _postRepository = postRepository;
    
    private readonly ILogger<GetPostsQueryHandler> _logger = logger;

    public async Task<Result<IEnumerable<Post>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request started: {0}", request.ToString());

        IEnumerable<Post> result = await _postRepository.ListAsync(
            request.ParentPostId
                .Map(p => (ISpecification<Post>)GetPostsByParentSpec.TryCreate(p))
                .Reduce(GetPostsAsNoTrackingSpec.Create()), 
            cancellationToken);
        
        _logger.LogInformation("Request was completed. Result is {0}", result.ToString());
        
        return Result<IEnumerable<Post>>.Success(result);
    }


}
