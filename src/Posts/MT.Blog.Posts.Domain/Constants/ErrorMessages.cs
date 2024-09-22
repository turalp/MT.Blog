namespace MT.Blog.Posts.Domain.Constants;

public static class ErrorMessages
{
    public static class Author 
    {
        public const string NotFound = "Author was not found. Please, specify right author in request and try again.";
    }

    public static class Post 
    {
        public const string NotFound = "Post was not found. Please, specify right post in request and try again.";
    }
}
