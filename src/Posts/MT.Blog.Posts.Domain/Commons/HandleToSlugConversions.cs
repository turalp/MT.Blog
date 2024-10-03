namespace MT.Blog.Posts.Domain.Commons;

public static class HandleToSlugConversions
{
    /// <summary>
    /// Concatenate of components.
    /// </summary>
    public static HandleToSlug Concatenate => handle => new(string.Join(string.Empty, handle.Components));

    /// <summary>
    /// Hyphenate of components.
    /// </summary>
    public static HandleToSlug Hyphenate => handle => new(string.Join('-', handle.Components));
}
