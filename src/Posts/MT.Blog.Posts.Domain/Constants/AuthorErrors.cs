using MT.Blog.Common.Functional;

namespace MT.Blog.Posts.Domain.Constants;

public static class AuthorErrors
{
    public static Error NotFound => Error.Create(ErrorMessages.Author.NotFound);
}
