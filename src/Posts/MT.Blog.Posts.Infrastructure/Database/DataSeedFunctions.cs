using MT.Blog.Posts.Domain.Entities;
using MT.Blog.Posts.Domain.Primaries;

namespace MT.Blog.Posts.Infrastructure.Database;

internal static class DataSeedFunctions
{
    public static Author[] Authors =>
    [
        Author.Create(AuthorId.Create(1), "Tural", "Mamedov")
    ];

    public static Category[] Categories =>
    [
        Category.Create(CategoryId.Create(1), ".NET", "url-to-icon"),
        Category.Create(CategoryId.Create(2), "Java", "url-to-icon"),
        Category.Create(CategoryId.Create(3), "JavaScript", "url-to-icon"),
        Category.Create(CategoryId.Create(4), "Frontend", "url-to-icon"),
        Category.Create(CategoryId.Create(5), "Python", "url-to-icon")
    ];

    public static Post[] Posts =>
    [
        Post.Create(PostId.Create(1), ".NET texnologiyalar", ".net-texnologiyalar", LoremIpsum, CategoryId.Create(1), AuthorId.Create(1), null),
        Post.Create(PostId.Create(2), ".NET nədir?", ".net-nadir", LoremIpsum, CategoryId.Create(1), AuthorId.Create(1), PostId.Create(1)),
        Post.Create(PostId.Create(3), ".NET əsasları: tiplər", ".net-asaslari", LoremIpsum, CategoryId.Create(1), AuthorId.Create(1), PostId.Create(1)),
        Post.Create(PostId.Create(4), "Klasslar və strukturalar", "klasslar-və-strukturalar", LoremIpsum, CategoryId.Create(1), AuthorId.Create(1), PostId.Create(3)),
        Post.Create(PostId.Create(5), "Record tipi", "record-tipi", LoremIpsum, CategoryId.Create(1), AuthorId.Create(1), PostId.Create(3)),
        Post.Create(PostId.Create(6), "Statik klasslar", "statik-klasslar", LoremIpsum, CategoryId.Create(1), AuthorId.Create(1), PostId.Create(3)),
        Post.Create(PostId.Create(7), "Abstrakt klasslar", "abstrakt-klasslar", LoremIpsum, CategoryId.Create(1), AuthorId.Create(1), PostId.Create(3)),
        Post.Create(PostId.Create(8), "Deleqatlar", "deleqatlar", LoremIpsum, CategoryId.Create(1), AuthorId.Create(1), PostId.Create(1)),
        Post.Create(PostId.Create(9), "Hadisələr", "hadisalar", LoremIpsum, CategoryId.Create(1), AuthorId.Create(1), PostId.Create(1)),
        Post.Create(PostId.Create(10), "İnterfeyslər", "interfeyslar", LoremIpsum, CategoryId.Create(1), AuthorId.Create(1), PostId.Create(1)),
    ];

    private static readonly string LoremIpsum = """
    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu finibus lorem. Nulla consequat efficitur ex, sed finibus velit interdum sit amet. Sed ut quam augue. In in urna metus. Quisque dapibus nisi ut massa mattis, id commodo mauris posuere. Duis viverra finibus lorem, id ornare nisi malesuada vitae. Sed interdum lectus et nibh pretium tincidunt. Praesent pretium sapien at convallis lobortis. Fusce id venenatis magna. Proin fringilla orci turpis, a posuere sem pretium ac. Vestibulum malesuada, tortor ac pulvinar cursus, lectus magna volutpat augue, nec scelerisque dui risus vitae orci. 
    Quisque justo urna, facilisis et euismod ut, cursus ac orci. Sed feugiat metus vitae massa dignissim, nec sagittis metus laoreet. Proin placerat dui ex, id condimentum diam placerat in. Suspendisse imperdiet malesuada erat ullamcorper molestie. Nunc eu gravida felis. Vestibulum a mattis metus, eget lobortis ipsum. Sed ac hendrerit purus, eget sollicitudin justo. Cras mattis quam eros. Curabitur porta, libero et rhoncus viverra, elit ligula sagittis mi, ut elementum augue neque sed augue. Nam erat neque, gravida in tincidunt sed, porttitor a mi. Maecenas quis odio eget magna rhoncus cursus sed a mi. Mauris vehicula lacinia malesuada.
    Phasellus in sagittis ex. Donec in laoreet nulla, at tincidunt ligula. Ut porta, magna ultrices efficitur sodales, tellus mi efficitur enim, ut egestas felis massa non nunc. Donec posuere viverra faucibus. Aenean ultrices ante neque, non egestas erat varius in. Suspendisse at dolor bibendum, dapibus erat id, ornare felis. Nulla nisi nunc, accumsan sit amet placerat vitae, tempor id erat. Etiam id venenatis turpis, a consequat nisl. Suspendisse vitae ante in tortor fringilla ultrices eu et justo. Fusce vehicula at arcu vitae tempor. Sed rhoncus ex a quam suscipit, ut lobortis augue gravida. Integer turpis felis, consectetur sit amet malesuada ac, egestas eget elit. Fusce eget tortor ut massa venenatis bibendum nec ac nisl.
    Vivamus turpis nibh, semper vel est at, molestie bibendum nibh. Integer dapibus nulla eu metus mattis, at porttitor sapien placerat. Vivamus ac sollicitudin urna. Vivamus eget dapibus augue. Cras placerat purus sit amet sem cursus, quis dictum ligula facilisis. Nulla ultrices feugiat lorem, nec dapibus elit congue nec. Sed cursus blandit lorem eget hendrerit. Donec tortor elit, euismod quis sagittis eget, fermentum eget dui.
    Aenean vitae orci id arcu viverra lacinia. Pellentesque id convallis purus. Vestibulum quis malesuada nisi. Nam gravida ex vel malesuada gravida. Sed at lorem enim. Ut feugiat auctor scelerisque. Vestibulum laoreet vel purus eleifend consequat.
    """;
}
