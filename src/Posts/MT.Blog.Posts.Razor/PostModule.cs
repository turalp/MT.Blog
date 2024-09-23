using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MT.Blog.Common.Constants;
using MT.Blog.Common.Converters;
using MT.Blog.Posts.Domain.Options;
using MT.Blog.Posts.Infrastructure.Database;
using MT.Blog.Posts.Infrastructure.Repositories.Concretes;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;

namespace MT.Blog.Posts.Razor;

public static class PostModule
{
    public static IServiceCollection RegisterPostModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(typeof(StronglyTypedIdConverter<>));
        services
            .AddDbContext<PostDbContext>(options => options
                .UseSqlServer(
                    configuration.GetSection("ConnectionStrings")["DatabaseConnectionString"]!, 
                    option => option.MigrationsHistoryTable(DatabaseConstants.MigrationTableName))
                .UseSnakeCaseNamingConvention());

        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(PostModule).Assembly));

        return services;
    }
}
