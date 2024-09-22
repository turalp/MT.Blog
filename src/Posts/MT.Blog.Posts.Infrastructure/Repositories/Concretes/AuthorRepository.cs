using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MT.Blog.Common.Extensions;
using MT.Blog.Common.Functional;
using MT.Blog.Common.Functional.Optional;
using MT.Blog.Posts.Domain.Constants;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;
using MT.Blog.Posts.Infrastructure.Database;
using MT.Blog.Posts.Infrastructure.Extensions;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;

namespace MT.Blog.Posts.Infrastructure.Repositories.Concretes;

public sealed class AuthorRepository(PostDbContext dbContext) : IAuthorRepository
{
    private readonly PostDbContext _dbContext = dbContext;

    public async Task<Author> CreateAsync(Author author, CancellationToken cancellationToken = default)
        => await author.AddAsync(_dbContext, cancellationToken);

    public async Task<Result<Author>> DeleteAsync(AuthorId authorId, CancellationToken cancellationToken = default)
        => (await GetAsync(authorId, cancellationToken))
            .Map(a => Result<Author>.Success(a.Delete(_dbContext)))
            .Reduce(AuthorErrors.NotFound);

    public async Task<Option<Author>> GetAsync(AuthorId authorId, CancellationToken cancellationToken = default) 
        => await _dbContext.Authors.AsQueryable().SingleOrNoneAsync(a => a.AuthorId == authorId, cancellationToken);

    public async Task<Option<Author>> GetAsync(
        ISingleResultSpecification<Author> specification, 
        CancellationToken cancellationToken = default) 
            => await _dbContext.ApplySpecification(specification).SingleOrNoneAsync(cancellationToken);

    public async Task<IEnumerable<Author>> ListAsync(ISpecification<Author> specification, CancellationToken cancellationToken = default)
        => await _dbContext.ApplySpecification(specification).ToArrayAsync(cancellationToken);

    public async Task<Result<Author>> UpdateAsync(Author author, CancellationToken cancellationToken = default)
        => (await GetAsync(author.AuthorId, cancellationToken))
            .Map(a => Result<Author>.Success(author.Update(_dbContext)))
            .Reduce(AuthorErrors.NotFound);
}
