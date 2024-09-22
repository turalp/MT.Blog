using MT.Blog.Common.Primaries;

namespace MT.Blog.Posts.Domain.Primaries;

public readonly record struct CommentId(int Value) : IStronglyTypedId<CommentId>
{
    public static CommentId Empty => new(int.MinValue);

    public static CommentId Create(int value) => new(value);
}
