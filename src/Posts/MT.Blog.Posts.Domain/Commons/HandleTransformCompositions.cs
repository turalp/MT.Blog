namespace MT.Blog.Posts.Domain.Commons;

public static class HandleTransformCompositions 
{
    /// <summary>
    /// Applies one transformation after another, e.g. .ToLowercase().Then(StopAtColon);
    /// </summary>
    /// <param name="first">First transformation.</param>
    /// <param name="second">Second transformation</param>
    /// <returns>The result of both transformations.</returns>
    public static TransformHandle Then(this TransformHandle first, TransformHandle second) =>
        handle => second(first(handle));

    /// <summary>
    /// Applies chain of transformations to handle type.
    /// </summary>
    /// <param name="handle">Entity that contains components.</param>
    /// <param name="transforms">Array of transformations that are supposed to use for handle entity.</param>
    /// <returns>Handle entity with transformed components.</returns>
    public static Handle Transform(this Handle handle, params TransformHandle[] transforms) =>
        transforms.Aggregate(handle, (current, transform) => transform(current));

    /// <summary>
    /// Converts handle entity to slug.
    /// </summary>
    /// <param name="handle">Entity that contains components.</param>
    /// <param name="conversion">Conversion function.</param>
    /// <returns>Slug value.</returns>
    public static Slug ToSlug(this Handle handle, HandleToSlug conversion) =>
        conversion(handle);
}
