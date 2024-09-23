using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MT.Blog.Common.Primaries;

namespace MT.Blog.Common.Converters;

public sealed class StronglyTypedIdConverter<T>(ConverterMappingHints? mappingHints = null)
    : ValueConverter<T, int>(
        stronglyTypedId => stronglyTypedId.Value,
        value => StronglyTypedLambda<T>.Create(value),
        mappingHints) where T : struct, IStronglyTypedId<T>
{
    public StronglyTypedIdConverter() : this(null)
    {
    }
}
