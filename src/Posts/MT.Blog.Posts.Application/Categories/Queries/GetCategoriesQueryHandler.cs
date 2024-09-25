using Microsoft.Extensions.Logging;
using MT.Blog.Common.Functional;
using MT.Blog.Common.Infrastructure;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;
using MT.Blog.Posts.Infrastructure.Specifications.Categories;

namespace MT.Blog.Posts.Application.Categories.Queries;

public class GetCategoriesQueryHandler(
    ICategoryRepository categoryRepository,
    ILogger<GetCategoriesQueryHandler> logger) : IQueryHandler<GetCategoriesQuery, IEnumerable<Category>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    
    private readonly ILogger<GetCategoriesQueryHandler> _logger = logger;

    public async Task<Result<IEnumerable<Category>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request started: {0}", request.ToString());

        IEnumerable<Category> result = await _categoryRepository.ListAsync(GetCategoriesSpec.Create(), cancellationToken);

        _logger.LogInformation("Request was completed. Result is {0}", result.ToString());

        return Result<IEnumerable<Category>>.Success(result);
    }
}
