using MT.Blog.Posts.Infrastructure.Repositories.Contracts;
using NSubstitute;

namespace MT.Blog.Posts.Tests.Mocks;

public static class RepositoryMocks
{
    public static IPostRepository GetPostRepositoryMock() => Substitute.For<IPostRepository>();
}
