using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MT.Blog.Common.Functional.Optional;

namespace MT.Blog.Common.Extensions;

public static class LinqExtensions
{
    public static async Task<Option<T>> SingleOrNoneAsync<T>(
        this IQueryable<T> source, 
        Expression<Func<T, bool>> expression, 
        CancellationToken cancellationToken = default)
            => await source
                .Where(expression)
                .DefaultIfEmpty()
                .Select(p => p == null ? None.Of<T>() : p.Optional())
                .SingleAsync(cancellationToken);

    public static async Task<Option<T>> SingleOrNoneAsync<T>(
        this IQueryable<T> source, 
        CancellationToken cancellationToken = default)
            => await source
                .DefaultIfEmpty()
                .Select(p => p == null ? None.Of<T>() : p.Optional())
                .SingleAsync(cancellationToken);
}
