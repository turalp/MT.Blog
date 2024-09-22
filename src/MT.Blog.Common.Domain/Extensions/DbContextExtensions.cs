using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MT.Blog.Common.Entities;

namespace MT.Blog.Common.Extensions;

public static class DbContextExtensions
{
    public static IQueryable<TEntity> ApplySpecification<TContext, TEntity>(this TContext dbContext, ISpecification<TEntity> specification)
        where TContext : DbContext
        where TEntity : class, IEntity 
            => SpecificationEvaluator.Default.GetQuery(dbContext.Set<TEntity>().AsQueryable(), specification);
}
