using Ardalis.Specification;
using MT.Blog.Common.Functional;
using MT.Blog.Common.Functional.Optional;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Repositories.Contracts;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category, CancellationToken cancellationToken = default);

    Task<Result<Category>> UpdateAsync(Category category, CancellationToken cancellationToken = default);

    Task<Result<Category>> DeleteAsync(CategoryId categoryId, CancellationToken cancellationToken = default);

    Task<Option<Category>> GetAsync(CategoryId categoryId, CancellationToken cancellationToken = default);

    Task<Option<Category>> GetAsync(ISingleResultSpecification<Category> specification, CancellationToken cancellationToken = default);

    Task<IEnumerable<Category>> ListAsync(ISpecification<Category> specification, CancellationToken cancellationToken = default);
}
