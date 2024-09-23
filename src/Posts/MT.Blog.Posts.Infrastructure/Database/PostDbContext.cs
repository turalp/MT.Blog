using Microsoft.EntityFrameworkCore;
using MT.Blog.Posts.Domain.Entities;

namespace MT.Blog.Posts.Infrastructure.Database;

/// <summary>
/// Database context for Posts module.
/// </summary>
public sealed class PostDbContext : DbContext
{
    private const string DefaultSchema = "posts";

    public PostDbContext()
    {
    }

    public PostDbContext(DbContextOptions<PostDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Post> Posts { get; init; }

    public DbSet<Comment> Comments { get; init; }

    public DbSet<Tag> Tags { get; init; }

    public DbSet<Author> Authors { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostDbContext).Assembly);
    }
}
