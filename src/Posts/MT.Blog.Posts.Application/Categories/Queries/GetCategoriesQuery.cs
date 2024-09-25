using MT.Blog.Common.Infrastructure;
using MT.Blog.Posts.Domain.Entities;

namespace MT.Blog.Posts.Application.Categories.Queries;

public sealed record class GetCategoriesQuery : IQuery<IEnumerable<Category>>
{
    public static GetCategoriesQuery Create() => new();

    public override string ToString()
    {
        return $"[GetCategoriesQuery] No parameters, running.";
    }
}
