using Microsoft.Extensions.DependencyInjection;
using MT.Blog.Posts.Infrastructure.Database;
using MT.Blog.Posts.Infrastructure.Repositories.Concretes;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;

namespace MT.Blog.Posts.Razor;

public static class PostModule
{
    public static IServiceCollection RegisterPostModule(this IServiceCollection services)
    {
        services.AddDbContext<PostDbContext>();

        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(PostModule).Assembly));

        return services;
    }
}
