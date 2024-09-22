using MT.Blog.Common.Primaries;

namespace MT.Blog.Posts.Domain.Primaries;

public readonly record struct AuthorId(int Value) : IStronglyTypedId<AuthorId>
{
    public static AuthorId Empty => new(int.MinValue);

    public static AuthorId Create(int value) => new(value);
}
