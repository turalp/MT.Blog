namespace MT.Blog.Common.Functional.Optional;

public abstract class Option<T> 
{
    public static implicit operator Option<T>(None _) => new None<T>();

    public static implicit operator Option<T>(T value) => new Some<T>(value);
}
