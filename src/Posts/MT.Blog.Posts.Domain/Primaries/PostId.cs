using MT.Blog.Common.Primaries;

namespace MT.Blog.Posts.Domain.Primaries;

public readonly record struct PostId(int Value) : IStronglyTypedId<PostId>
{
    public static PostId Empty => new(int.MinValue);

    public static PostId Create(int value) => new(value);

    public static implicit operator int(PostId categoryId) => categoryId.Value;

    public static implicit operator PostId(int value) => Create(value);
}