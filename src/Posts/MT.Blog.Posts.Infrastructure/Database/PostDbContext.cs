using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MT.Blog.Common.Constants;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Options;
using MT.Blog.Posts.Infrastructure.Database.Interceptors;

namespace MT.Blog.Posts.Infrastructure.Database;

/// <summary>
/// Database context for Posts module.
/// </summary>
public sealed class PostDbContext(IOptions<DatabaseOptions> options, IServiceCollection serviceCollection) : DbContext
{
    private const string DefaultSchema = "posts";
    
    private readonly IOptions<DatabaseOptions> _options = options;

    private readonly IServiceCollection _serviceCollection = serviceCollection;

    public DbSet<Post> Posts { get; init; }

    public DbSet<Comment> Comments { get; init; }

    public DbSet<Tag> Tags { get; init; }

    public DbSet<Author> Authors { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        using var serviceProvider = _serviceCollection.BuildServiceProvider();
        optionsBuilder
            .UseSqlServer(
                _options.Value.DatabaseConnectionString, 
                options => options.MigrationsHistoryTable(DatabaseConstants.MigrationTableName))
            .UseSnakeCaseNamingConvention()
            .AddInterceptors(serviceProvider.GetRequiredService<AuditableInterceptor>());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostDbContext).Assembly);
    }
}
