using MT.Blog.Common.Functional;

namespace MT.Blog.Posts.Domain.Constants;

public static class PostErrors
{
    public static Error NotFound = Error.Create(ErrorMessages.Post.NotFound);
}
