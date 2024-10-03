namespace MT.Blog.Posts.Domain.Commons;

public record class Handle(params string[] Components);

public delegate Slug HandleToSlug(Handle Handle);

public delegate Handle TransformHandle(Handle handle);
