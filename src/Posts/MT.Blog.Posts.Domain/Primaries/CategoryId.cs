using MT.Blog.Common.Primaries;

namespace MT.Blog.Posts.Domain.Primaries;

public readonly record struct CategoryId(int Value) : IStronglyTypedId<CategoryId>
{
    public static CategoryId Empty => new(int.MinValue);

    public static CategoryId Create(int value) => new(value);
}
