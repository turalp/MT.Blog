namespace MT.Blog.Common.Functional.Optional;

public sealed class Some<T>(T content) : Option<T>
{
    public T Content { get; } = content;

    public override string ToString() => $"Some {Content?.ToString() ?? "<null>"}";
}
