using MT.Blog.Common.Primaries;

namespace MT.Blog.Common.Converters;

internal sealed class StronglyTypedLambda<T> where T : struct, IStronglyTypedId<T>
{
    internal static T Create(int value) => T.Create(value);
}
