using Ardalis.Specification;
using MT.Blog.Common.Functional;
using MT.Blog.Common.Functional.Optional;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Repositories.Contracts;

public interface IAuthorRepository
{
    Task<Author> CreateAsync(Author author, CancellationToken cancellationToken = default);

    Task<Result<Author>> UpdateAsync(Author author, CancellationToken cancellationToken = default);

    Task<Result<Author>> DeleteAsync(AuthorId authorId, CancellationToken cancellationToken = default);

    Task<Option<Author>> GetAsync(AuthorId authorId, CancellationToken cancellationToken = default);

    Task<Option<Author>> GetAsync(ISingleResultSpecification<Author> specification, CancellationToken cancellationToken = default);

    Task<IEnumerable<Author>> ListAsync(ISpecification<Author> specification, CancellationToken cancellationToken = default);
}
