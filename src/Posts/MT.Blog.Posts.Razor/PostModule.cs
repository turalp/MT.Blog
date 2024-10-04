using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MT.Blog.Common.Constants;
using MT.Blog.Common.Converters;
using MT.Blog.Posts.Application;
using MT.Blog.Posts.Domain.Commons;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Infrastructure.Database;
using MT.Blog.Posts.Infrastructure.Repositories.Concretes;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;
using static MT.Blog.Posts.Domain.Commons.HandleTransforms;
using static MT.Blog.Posts.Domain.Commons.HandleToSlugConversions;

namespace MT.Blog.Posts.Razor;

public static class PostModule
{
    public static IServiceCollection RegisterPostModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(typeof(StronglyTypedIdConverter<>));
        services.AddSingleton<PostTitleToSlug>(_ => (culture, title) =>
            new Handle(title)
                .Transform(ToLowercase(culture), StopAtColon, IntoLetterAndDigitRuns, ReplaceAzerbaijaniLetters)
                .ToSlug(Hyphenate));
        
        services
            .AddDbContext<PostDbContext>(options => options
                .UseSqlServer(
                    configuration.GetSection("ConnectionStrings")["DatabaseConnectionString"]!, 
                    option => option.MigrationsHistoryTable(DatabaseConstants.MigrationTableName))
                .UseSnakeCaseNamingConvention());

        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        
        services.RegisterPostApplication();

        return services;
    }
}
