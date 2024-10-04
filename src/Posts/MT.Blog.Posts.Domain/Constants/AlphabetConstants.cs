namespace MT.Blog.Posts.Domain.Constants;

public static class AlphabetConstants
{
    public static IReadOnlyDictionary<char, char> SlugLetterReplacement = new Dictionary<char, char>
    {
        { 'ə', 'a' },
        { 'ü', 'u' },
        { 'ğ', 'g' },
        { 'ö', 'o' },
        { 'ı', 'i' }
    };
}
