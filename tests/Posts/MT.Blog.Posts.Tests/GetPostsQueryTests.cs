using MT.Blog.Posts.Infrastructure.Repositories.Contracts;
using MT.Blog.Posts.Tests.Mocks;

namespace MT.Blog.Posts.Tests;

[TestFixture]
public sealed class GetPostsQueryTests
{
    private readonly IPostRepository _repository;

    public GetPostsQueryTests()
    {
        _repository = RepositoryMocks.GetPostRepositoryMock();
        _repository.SetupListAsync();
    }

    [Test]
    public void UnitTest() => Assert.True(true);
}
