namespace MT.Blog.Common.Primaries;

public interface IStronglyTypedId<T> where T : struct
{
    public int Value { get; init; }

    public abstract static T Create(int value);
}
