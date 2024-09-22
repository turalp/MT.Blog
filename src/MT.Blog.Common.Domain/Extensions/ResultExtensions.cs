using MT.Blog.Common.Functional;

namespace MT.Blog.Common.Extensions;

public static class ResultExtensions
{
    public static T Match<T>(this Result<T> result) => throw new NotImplementedException();

    public static Task<T> MatchAsync<T>(this Result<T> result) => throw new NotImplementedException();
}
