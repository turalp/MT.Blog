using Ardalis.Specification;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Specifications;

public sealed class GetAuthorByIdSpec : SingleResultSpecification<Author>, ISingleResultSpecification<Author>
{
    private GetAuthorByIdSpec(AuthorId authorId) 
    {
        Query
            .Where(author => author.AuthorId == authorId);
    }
}
