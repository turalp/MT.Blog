using Bogus;
using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Tests.Fakers;

public sealed class PostFaker : Faker<Post>
{
    private PostFaker()
    {
        RuleFor(p => p.PostId, f => PostId.Create(f.Random.Number(1, 100)));
        RuleFor(p => p.Title, f => f.Lorem.Sentance());
        RuleFor(p => p.Description, f => f.Lorem.Sentances());
        RuleFor(p => p.CategoryId, f => CategoryId.Create(f.Random.Number(1, 100)));
    }

    public static PostFaker Create() => new();
}
