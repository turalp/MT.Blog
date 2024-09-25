using Ardalis.Specification;
using MT.Blog.Posts.Domain.Entities;

namespace MT.Blog.Posts.Infrastructure.Specifications.Categories;

public sealed class GetCategoriesSpec : Specification<Category>, ISpecification<Category>
{
    private GetCategoriesSpec() => Query.AsTracking();

    public static GetCategoriesSpec Create() => new();
}
