namespace MT.Blog.Common.Functional;

public sealed record class Error(string Description)
{
    public static readonly Error None = new(string.Empty);

    public static Error Create(string description) => new(description);
}
