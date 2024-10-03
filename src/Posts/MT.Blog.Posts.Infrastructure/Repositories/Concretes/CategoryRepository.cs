using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MT.Blog.Common.Extensions;
using MT.Blog.Common.Functional;
using MT.Blog.Common.Functional.Optional;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;
using MT.Blog.Posts.Infrastructure.Database;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;

namespace MT.Blog.Posts.Infrastructure.Repositories.Concretes;

public sealed class CategoryRepository(PostDbContext dbContext) : ICategoryRepository
{
    private readonly PostDbContext _dbContext = dbContext;

    public Task<Category> CreateAsync(Category category, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Category>> DeleteAsync(CategoryId categoryId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Option<Category>> GetAsync(CategoryId categoryId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Option<Category>> GetAsync(ISingleResultSpecification<Category> specification, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> ListAsync(ISpecification<Category> specification, CancellationToken cancellationToken = default)
        => await _dbContext.ApplySpecification(specification).ToArrayAsync(cancellationToken);
    
    public Task<Result<Category>> UpdateAsync(Category category, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
