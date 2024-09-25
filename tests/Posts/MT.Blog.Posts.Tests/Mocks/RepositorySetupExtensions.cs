using Ardalis.Specification;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Infrastructure.Repositories.Contracts;
using MT.Blog.Posts.Tests.Fakers;
using NSubstitute;
using NSubstitute.Core;

namespace MT.Blog.Posts.Tests.Mocks;

public static class RepositorySetupExtensions
{
    public static ConfiguredCall SetupListAsync(this IPostRepository repository) 
        => repository.ListAsync(Arg.Any<ISpecification<Post>>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult<IEnumerable<Post>>([PostFaker.Create().Generate()]));


}
