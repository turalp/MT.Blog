namespace MT.Blog.Common.Functional.Optional;

public sealed class None<T> : Option<T>
{
    public override string ToString() => "None";
}

public sealed class None 
{
    private None()
    {
    }

    public static None Value { get; } = new();

    public static None<T> Of<T>() => new None<T>();
}