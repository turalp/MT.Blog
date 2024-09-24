using Microsoft.Extensions.DependencyInjection;

namespace MT.Blog.Posts.Application;

public static class RegisterPostApp
{
    public static IServiceCollection RegisterPostApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterPostApp).Assembly));

        return services;
    }
}
