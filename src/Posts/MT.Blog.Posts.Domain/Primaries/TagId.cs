using MT.Blog.Common.Primaries;

namespace MT.Blog.Posts.Domain.Primaries;

public readonly record struct TagId(int Value) : IStronglyTypedId<TagId>
{
    public static TagId Empty => new(int.MinValue);

    public static TagId Create(int value) => new(value);
}
