using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MT.Blog.Posts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "posts");

            migrationBuilder.CreateTable(
                name: "authors",
                schema: "posts",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    creator_author_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_authors", x => x.author_id);
                    table.ForeignKey(
                        name: "fk_authors_authors_creator_author_id",
                        column: x => x.creator_author_id,
                        principalSchema: "posts",
                        principalTable: "authors",
                        principalColumn: "author_id");
                });

            migrationBuilder.CreateTable(
                name: "category",
                schema: "posts",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    icon_url = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    creator_author_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.category_id);
                    table.ForeignKey(
                        name: "fk_category_authors_creator_author_id",
                        column: x => x.creator_author_id,
                        principalSchema: "posts",
                        principalTable: "authors",
                        principalColumn: "author_id");
                });

            migrationBuilder.CreateTable(
                name: "tags",
                schema: "posts",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.tag_id);
                    table.ForeignKey(
                        name: "fk_tags_authors_created_by",
                        column: x => x.created_by,
                        principalSchema: "posts",
                        principalTable: "authors",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                schema: "posts",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    key = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parent_post_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_posts", x => x.post_id);
                    table.ForeignKey(
                        name: "fk_posts_authors_created_by",
                        column: x => x.created_by,
                        principalSchema: "posts",
                        principalTable: "authors",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_posts_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "posts",
                        principalTable: "category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_posts_posts_parent_post_id",
                        column: x => x.parent_post_id,
                        principalSchema: "posts",
                        principalTable: "posts",
                        principalColumn: "post_id");
                });

            migrationBuilder.CreateTable(
                name: "comments",
                schema: "posts",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    body = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    parent_id = table.Column<int>(type: "int", nullable: true),
                    post_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comments", x => x.comment_id);
                    table.ForeignKey(
                        name: "fk_comments_authors_created_by",
                        column: x => x.created_by,
                        principalSchema: "posts",
                        principalTable: "authors",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_comments_comments_parent_id",
                        column: x => x.parent_id,
                        principalSchema: "posts",
                        principalTable: "comments",
                        principalColumn: "comment_id");
                    table.ForeignKey(
                        name: "fk_comments_posts_post_id",
                        column: x => x.post_id,
                        principalSchema: "posts",
                        principalTable: "posts",
                        principalColumn: "post_id");
                });

            migrationBuilder.CreateTable(
                name: "post_tag",
                schema: "posts",
                columns: table => new
                {
                    posts_post_id = table.Column<int>(type: "int", nullable: false),
                    tags_tag_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_post_tag", x => new { x.posts_post_id, x.tags_tag_id });
                    table.ForeignKey(
                        name: "fk_post_tag_posts_posts_post_id",
                        column: x => x.posts_post_id,
                        principalSchema: "posts",
                        principalTable: "posts",
                        principalColumn: "post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_post_tag_tags_tags_tag_id",
                        column: x => x.tags_tag_id,
                        principalSchema: "posts",
                        principalTable: "tags",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                schema: "posts",
                table: "authors",
                columns: new[] { "author_id", "created_at", "created_by", "creator_author_id", "first_name", "last_name", "updated_at", "updated_by" },
                values: new object[] { 1, new DateTime(2024, 10, 4, 4, 41, 4, 851, DateTimeKind.Utc).AddTicks(7552), 0, null, "Tural", "Mamedov", null, null });

            migrationBuilder.InsertData(
                schema: "posts",
                table: "category",
                columns: new[] { "category_id", "created_at", "created_by", "creator_author_id", "icon_url", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 4, 4, 41, 4, 854, DateTimeKind.Utc).AddTicks(3901), 1, null, "url-to-icon", ".NET", null, null },
                    { 2, new DateTime(2024, 10, 4, 4, 41, 4, 854, DateTimeKind.Utc).AddTicks(3921), 1, null, "url-to-icon", "Java", null, null },
                    { 3, new DateTime(2024, 10, 4, 4, 41, 4, 854, DateTimeKind.Utc).AddTicks(3923), 1, null, "url-to-icon", "JavaScript", null, null },
                    { 4, new DateTime(2024, 10, 4, 4, 41, 4, 854, DateTimeKind.Utc).AddTicks(3924), 1, null, "url-to-icon", "Frontend", null, null },
                    { 5, new DateTime(2024, 10, 4, 4, 41, 4, 854, DateTimeKind.Utc).AddTicks(3925), 1, null, "url-to-icon", "Python", null, null }
                });

            migrationBuilder.InsertData(
                schema: "posts",
                table: "posts",
                columns: new[] { "post_id", "category_id", "created_at", "created_by", "description", "key", "parent_post_id", "title", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 4, 4, 41, 4, 860, DateTimeKind.Utc).AddTicks(1834), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu finibus lorem. Nulla consequat efficitur ex, sed finibus velit interdum sit amet. Sed ut quam augue. In in urna metus. Quisque dapibus nisi ut massa mattis, id commodo mauris posuere. Duis viverra finibus lorem, id ornare nisi malesuada vitae. Sed interdum lectus et nibh pretium tincidunt. Praesent pretium sapien at convallis lobortis. Fusce id venenatis magna. Proin fringilla orci turpis, a posuere sem pretium ac. Vestibulum malesuada, tortor ac pulvinar cursus, lectus magna volutpat augue, nec scelerisque dui risus vitae orci. \r\nQuisque justo urna, facilisis et euismod ut, cursus ac orci. Sed feugiat metus vitae massa dignissim, nec sagittis metus laoreet. Proin placerat dui ex, id condimentum diam placerat in. Suspendisse imperdiet malesuada erat ullamcorper molestie. Nunc eu gravida felis. Vestibulum a mattis metus, eget lobortis ipsum. Sed ac hendrerit purus, eget sollicitudin justo. Cras mattis quam eros. Curabitur porta, libero et rhoncus viverra, elit ligula sagittis mi, ut elementum augue neque sed augue. Nam erat neque, gravida in tincidunt sed, porttitor a mi. Maecenas quis odio eget magna rhoncus cursus sed a mi. Mauris vehicula lacinia malesuada.\r\nPhasellus in sagittis ex. Donec in laoreet nulla, at tincidunt ligula. Ut porta, magna ultrices efficitur sodales, tellus mi efficitur enim, ut egestas felis massa non nunc. Donec posuere viverra faucibus. Aenean ultrices ante neque, non egestas erat varius in. Suspendisse at dolor bibendum, dapibus erat id, ornare felis. Nulla nisi nunc, accumsan sit amet placerat vitae, tempor id erat. Etiam id venenatis turpis, a consequat nisl. Suspendisse vitae ante in tortor fringilla ultrices eu et justo. Fusce vehicula at arcu vitae tempor. Sed rhoncus ex a quam suscipit, ut lobortis augue gravida. Integer turpis felis, consectetur sit amet malesuada ac, egestas eget elit. Fusce eget tortor ut massa venenatis bibendum nec ac nisl.\r\nVivamus turpis nibh, semper vel est at, molestie bibendum nibh. Integer dapibus nulla eu metus mattis, at porttitor sapien placerat. Vivamus ac sollicitudin urna. Vivamus eget dapibus augue. Cras placerat purus sit amet sem cursus, quis dictum ligula facilisis. Nulla ultrices feugiat lorem, nec dapibus elit congue nec. Sed cursus blandit lorem eget hendrerit. Donec tortor elit, euismod quis sagittis eget, fermentum eget dui.\r\nAenean vitae orci id arcu viverra lacinia. Pellentesque id convallis purus. Vestibulum quis malesuada nisi. Nam gravida ex vel malesuada gravida. Sed at lorem enim. Ut feugiat auctor scelerisque. Vestibulum laoreet vel purus eleifend consequat.", ".net-texnologiyalar", null, ".NET texnologiyalar", null, null },
                    { 2, 1, new DateTime(2024, 10, 4, 4, 41, 4, 860, DateTimeKind.Utc).AddTicks(1839), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu finibus lorem. Nulla consequat efficitur ex, sed finibus velit interdum sit amet. Sed ut quam augue. In in urna metus. Quisque dapibus nisi ut massa mattis, id commodo mauris posuere. Duis viverra finibus lorem, id ornare nisi malesuada vitae. Sed interdum lectus et nibh pretium tincidunt. Praesent pretium sapien at convallis lobortis. Fusce id venenatis magna. Proin fringilla orci turpis, a posuere sem pretium ac. Vestibulum malesuada, tortor ac pulvinar cursus, lectus magna volutpat augue, nec scelerisque dui risus vitae orci. \r\nQuisque justo urna, facilisis et euismod ut, cursus ac orci. Sed feugiat metus vitae massa dignissim, nec sagittis metus laoreet. Proin placerat dui ex, id condimentum diam placerat in. Suspendisse imperdiet malesuada erat ullamcorper molestie. Nunc eu gravida felis. Vestibulum a mattis metus, eget lobortis ipsum. Sed ac hendrerit purus, eget sollicitudin justo. Cras mattis quam eros. Curabitur porta, libero et rhoncus viverra, elit ligula sagittis mi, ut elementum augue neque sed augue. Nam erat neque, gravida in tincidunt sed, porttitor a mi. Maecenas quis odio eget magna rhoncus cursus sed a mi. Mauris vehicula lacinia malesuada.\r\nPhasellus in sagittis ex. Donec in laoreet nulla, at tincidunt ligula. Ut porta, magna ultrices efficitur sodales, tellus mi efficitur enim, ut egestas felis massa non nunc. Donec posuere viverra faucibus. Aenean ultrices ante neque, non egestas erat varius in. Suspendisse at dolor bibendum, dapibus erat id, ornare felis. Nulla nisi nunc, accumsan sit amet placerat vitae, tempor id erat. Etiam id venenatis turpis, a consequat nisl. Suspendisse vitae ante in tortor fringilla ultrices eu et justo. Fusce vehicula at arcu vitae tempor. Sed rhoncus ex a quam suscipit, ut lobortis augue gravida. Integer turpis felis, consectetur sit amet malesuada ac, egestas eget elit. Fusce eget tortor ut massa venenatis bibendum nec ac nisl.\r\nVivamus turpis nibh, semper vel est at, molestie bibendum nibh. Integer dapibus nulla eu metus mattis, at porttitor sapien placerat. Vivamus ac sollicitudin urna. Vivamus eget dapibus augue. Cras placerat purus sit amet sem cursus, quis dictum ligula facilisis. Nulla ultrices feugiat lorem, nec dapibus elit congue nec. Sed cursus blandit lorem eget hendrerit. Donec tortor elit, euismod quis sagittis eget, fermentum eget dui.\r\nAenean vitae orci id arcu viverra lacinia. Pellentesque id convallis purus. Vestibulum quis malesuada nisi. Nam gravida ex vel malesuada gravida. Sed at lorem enim. Ut feugiat auctor scelerisque. Vestibulum laoreet vel purus eleifend consequat.", ".net-nadir", 1, ".NET nədir?", null, null },
                    { 3, 1, new DateTime(2024, 10, 4, 4, 41, 4, 860, DateTimeKind.Utc).AddTicks(1841), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu finibus lorem. Nulla consequat efficitur ex, sed finibus velit interdum sit amet. Sed ut quam augue. In in urna metus. Quisque dapibus nisi ut massa mattis, id commodo mauris posuere. Duis viverra finibus lorem, id ornare nisi malesuada vitae. Sed interdum lectus et nibh pretium tincidunt. Praesent pretium sapien at convallis lobortis. Fusce id venenatis magna. Proin fringilla orci turpis, a posuere sem pretium ac. Vestibulum malesuada, tortor ac pulvinar cursus, lectus magna volutpat augue, nec scelerisque dui risus vitae orci. \r\nQuisque justo urna, facilisis et euismod ut, cursus ac orci. Sed feugiat metus vitae massa dignissim, nec sagittis metus laoreet. Proin placerat dui ex, id condimentum diam placerat in. Suspendisse imperdiet malesuada erat ullamcorper molestie. Nunc eu gravida felis. Vestibulum a mattis metus, eget lobortis ipsum. Sed ac hendrerit purus, eget sollicitudin justo. Cras mattis quam eros. Curabitur porta, libero et rhoncus viverra, elit ligula sagittis mi, ut elementum augue neque sed augue. Nam erat neque, gravida in tincidunt sed, porttitor a mi. Maecenas quis odio eget magna rhoncus cursus sed a mi. Mauris vehicula lacinia malesuada.\r\nPhasellus in sagittis ex. Donec in laoreet nulla, at tincidunt ligula. Ut porta, magna ultrices efficitur sodales, tellus mi efficitur enim, ut egestas felis massa non nunc. Donec posuere viverra faucibus. Aenean ultrices ante neque, non egestas erat varius in. Suspendisse at dolor bibendum, dapibus erat id, ornare felis. Nulla nisi nunc, accumsan sit amet placerat vitae, tempor id erat. Etiam id venenatis turpis, a consequat nisl. Suspendisse vitae ante in tortor fringilla ultrices eu et justo. Fusce vehicula at arcu vitae tempor. Sed rhoncus ex a quam suscipit, ut lobortis augue gravida. Integer turpis felis, consectetur sit amet malesuada ac, egestas eget elit. Fusce eget tortor ut massa venenatis bibendum nec ac nisl.\r\nVivamus turpis nibh, semper vel est at, molestie bibendum nibh. Integer dapibus nulla eu metus mattis, at porttitor sapien placerat. Vivamus ac sollicitudin urna. Vivamus eget dapibus augue. Cras placerat purus sit amet sem cursus, quis dictum ligula facilisis. Nulla ultrices feugiat lorem, nec dapibus elit congue nec. Sed cursus blandit lorem eget hendrerit. Donec tortor elit, euismod quis sagittis eget, fermentum eget dui.\r\nAenean vitae orci id arcu viverra lacinia. Pellentesque id convallis purus. Vestibulum quis malesuada nisi. Nam gravida ex vel malesuada gravida. Sed at lorem enim. Ut feugiat auctor scelerisque. Vestibulum laoreet vel purus eleifend consequat.", ".net-asaslari", 1, ".NET əsasları: tiplər", null, null },
                    { 8, 1, new DateTime(2024, 10, 4, 4, 41, 4, 860, DateTimeKind.Utc).AddTicks(1852), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu finibus lorem. Nulla consequat efficitur ex, sed finibus velit interdum sit amet. Sed ut quam augue. In in urna metus. Quisque dapibus nisi ut massa mattis, id commodo mauris posuere. Duis viverra finibus lorem, id ornare nisi malesuada vitae. Sed interdum lectus et nibh pretium tincidunt. Praesent pretium sapien at convallis lobortis. Fusce id venenatis magna. Proin fringilla orci turpis, a posuere sem pretium ac. Vestibulum malesuada, tortor ac pulvinar cursus, lectus magna volutpat augue, nec scelerisque dui risus vitae orci. \r\nQuisque justo urna, facilisis et euismod ut, cursus ac orci. Sed feugiat metus vitae massa dignissim, nec sagittis metus laoreet. Proin placerat dui ex, id condimentum diam placerat in. Suspendisse imperdiet malesuada erat ullamcorper molestie. Nunc eu gravida felis. Vestibulum a mattis metus, eget lobortis ipsum. Sed ac hendrerit purus, eget sollicitudin justo. Cras mattis quam eros. Curabitur porta, libero et rhoncus viverra, elit ligula sagittis mi, ut elementum augue neque sed augue. Nam erat neque, gravida in tincidunt sed, porttitor a mi. Maecenas quis odio eget magna rhoncus cursus sed a mi. Mauris vehicula lacinia malesuada.\r\nPhasellus in sagittis ex. Donec in laoreet nulla, at tincidunt ligula. Ut porta, magna ultrices efficitur sodales, tellus mi efficitur enim, ut egestas felis massa non nunc. Donec posuere viverra faucibus. Aenean ultrices ante neque, non egestas erat varius in. Suspendisse at dolor bibendum, dapibus erat id, ornare felis. Nulla nisi nunc, accumsan sit amet placerat vitae, tempor id erat. Etiam id venenatis turpis, a consequat nisl. Suspendisse vitae ante in tortor fringilla ultrices eu et justo. Fusce vehicula at arcu vitae tempor. Sed rhoncus ex a quam suscipit, ut lobortis augue gravida. Integer turpis felis, consectetur sit amet malesuada ac, egestas eget elit. Fusce eget tortor ut massa venenatis bibendum nec ac nisl.\r\nVivamus turpis nibh, semper vel est at, molestie bibendum nibh. Integer dapibus nulla eu metus mattis, at porttitor sapien placerat. Vivamus ac sollicitudin urna. Vivamus eget dapibus augue. Cras placerat purus sit amet sem cursus, quis dictum ligula facilisis. Nulla ultrices feugiat lorem, nec dapibus elit congue nec. Sed cursus blandit lorem eget hendrerit. Donec tortor elit, euismod quis sagittis eget, fermentum eget dui.\r\nAenean vitae orci id arcu viverra lacinia. Pellentesque id convallis purus. Vestibulum quis malesuada nisi. Nam gravida ex vel malesuada gravida. Sed at lorem enim. Ut feugiat auctor scelerisque. Vestibulum laoreet vel purus eleifend consequat.", "deleqatlar", 1, "Deleqatlar", null, null },
                    { 9, 1, new DateTime(2024, 10, 4, 4, 41, 4, 860, DateTimeKind.Utc).AddTicks(1853), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu finibus lorem. Nulla consequat efficitur ex, sed finibus velit interdum sit amet. Sed ut quam augue. In in urna metus. Quisque dapibus nisi ut massa mattis, id commodo mauris posuere. Duis viverra finibus lorem, id ornare nisi malesuada vitae. Sed interdum lectus et nibh pretium tincidunt. Praesent pretium sapien at convallis lobortis. Fusce id venenatis magna. Proin fringilla orci turpis, a posuere sem pretium ac. Vestibulum malesuada, tortor ac pulvinar cursus, lectus magna volutpat augue, nec scelerisque dui risus vitae orci. \r\nQuisque justo urna, facilisis et euismod ut, cursus ac orci. Sed feugiat metus vitae massa dignissim, nec sagittis metus laoreet. Proin placerat dui ex, id condimentum diam placerat in. Suspendisse imperdiet malesuada erat ullamcorper molestie. Nunc eu gravida felis. Vestibulum a mattis metus, eget lobortis ipsum. Sed ac hendrerit purus, eget sollicitudin justo. Cras mattis quam eros. Curabitur porta, libero et rhoncus viverra, elit ligula sagittis mi, ut elementum augue neque sed augue. Nam erat neque, gravida in tincidunt sed, porttitor a mi. Maecenas quis odio eget magna rhoncus cursus sed a mi. Mauris vehicula lacinia malesuada.\r\nPhasellus in sagittis ex. Donec in laoreet nulla, at tincidunt ligula. Ut porta, magna ultrices efficitur sodales, tellus mi efficitur enim, ut egestas felis massa non nunc. Donec posuere viverra faucibus. Aenean ultrices ante neque, non egestas erat varius in. Suspendisse at dolor bibendum, dapibus erat id, ornare felis. Nulla nisi nunc, accumsan sit amet placerat vitae, tempor id erat. Etiam id venenatis turpis, a consequat nisl. Suspendisse vitae ante in tortor fringilla ultrices eu et justo. Fusce vehicula at arcu vitae tempor. Sed rhoncus ex a quam suscipit, ut lobortis augue gravida. Integer turpis felis, consectetur sit amet malesuada ac, egestas eget elit. Fusce eget tortor ut massa venenatis bibendum nec ac nisl.\r\nVivamus turpis nibh, semper vel est at, molestie bibendum nibh. Integer dapibus nulla eu metus mattis, at porttitor sapien placerat. Vivamus ac sollicitudin urna. Vivamus eget dapibus augue. Cras placerat purus sit amet sem cursus, quis dictum ligula facilisis. Nulla ultrices feugiat lorem, nec dapibus elit congue nec. Sed cursus blandit lorem eget hendrerit. Donec tortor elit, euismod quis sagittis eget, fermentum eget dui.\r\nAenean vitae orci id arcu viverra lacinia. Pellentesque id convallis purus. Vestibulum quis malesuada nisi. Nam gravida ex vel malesuada gravida. Sed at lorem enim. Ut feugiat auctor scelerisque. Vestibulum laoreet vel purus eleifend consequat.", "hadisalar", 1, "Hadisələr", null, null },
                    { 10, 1, new DateTime(2024, 10, 4, 4, 41, 4, 860, DateTimeKind.Utc).AddTicks(1855), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu finibus lorem. Nulla consequat efficitur ex, sed finibus velit interdum sit amet. Sed ut quam augue. In in urna metus. Quisque dapibus nisi ut massa mattis, id commodo mauris posuere. Duis viverra finibus lorem, id ornare nisi malesuada vitae. Sed interdum lectus et nibh pretium tincidunt. Praesent pretium sapien at convallis lobortis. Fusce id venenatis magna. Proin fringilla orci turpis, a posuere sem pretium ac. Vestibulum malesuada, tortor ac pulvinar cursus, lectus magna volutpat augue, nec scelerisque dui risus vitae orci. \r\nQuisque justo urna, facilisis et euismod ut, cursus ac orci. Sed feugiat metus vitae massa dignissim, nec sagittis metus laoreet. Proin placerat dui ex, id condimentum diam placerat in. Suspendisse imperdiet malesuada erat ullamcorper molestie. Nunc eu gravida felis. Vestibulum a mattis metus, eget lobortis ipsum. Sed ac hendrerit purus, eget sollicitudin justo. Cras mattis quam eros. Curabitur porta, libero et rhoncus viverra, elit ligula sagittis mi, ut elementum augue neque sed augue. Nam erat neque, gravida in tincidunt sed, porttitor a mi. Maecenas quis odio eget magna rhoncus cursus sed a mi. Mauris vehicula lacinia malesuada.\r\nPhasellus in sagittis ex. Donec in laoreet nulla, at tincidunt ligula. Ut porta, magna ultrices efficitur sodales, tellus mi efficitur enim, ut egestas felis massa non nunc. Donec posuere viverra faucibus. Aenean ultrices ante neque, non egestas erat varius in. Suspendisse at dolor bibendum, dapibus erat id, ornare felis. Nulla nisi nunc, accumsan sit amet placerat vitae, tempor id erat. Etiam id venenatis turpis, a consequat nisl. Suspendisse vitae ante in tortor fringilla ultrices eu et justo. Fusce vehicula at arcu vitae tempor. Sed rhoncus ex a quam suscipit, ut lobortis augue gravida. Integer turpis felis, consectetur sit amet malesuada ac, egestas eget elit. Fusce eget tortor ut massa venenatis bibendum nec ac nisl.\r\nVivamus turpis nibh, semper vel est at, molestie bibendum nibh. Integer dapibus nulla eu metus mattis, at porttitor sapien placerat. Vivamus ac sollicitudin urna. Vivamus eget dapibus augue. Cras placerat purus sit amet sem cursus, quis dictum ligula facilisis. Nulla ultrices feugiat lorem, nec dapibus elit congue nec. Sed cursus blandit lorem eget hendrerit. Donec tortor elit, euismod quis sagittis eget, fermentum eget dui.\r\nAenean vitae orci id arcu viverra lacinia. Pellentesque id convallis purus. Vestibulum quis malesuada nisi. Nam gravida ex vel malesuada gravida. Sed at lorem enim. Ut feugiat auctor scelerisque. Vestibulum laoreet vel purus eleifend consequat.", "interfeyslar", 1, "İnterfeyslər", null, null },
                    { 4, 1, new DateTime(2024, 10, 4, 4, 41, 4, 860, DateTimeKind.Utc).AddTicks(1843), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu finibus lorem. Nulla consequat efficitur ex, sed finibus velit interdum sit amet. Sed ut quam augue. In in urna metus. Quisque dapibus nisi ut massa mattis, id commodo mauris posuere. Duis viverra finibus lorem, id ornare nisi malesuada vitae. Sed interdum lectus et nibh pretium tincidunt. Praesent pretium sapien at convallis lobortis. Fusce id venenatis magna. Proin fringilla orci turpis, a posuere sem pretium ac. Vestibulum malesuada, tortor ac pulvinar cursus, lectus magna volutpat augue, nec scelerisque dui risus vitae orci. \r\nQuisque justo urna, facilisis et euismod ut, cursus ac orci. Sed feugiat metus vitae massa dignissim, nec sagittis metus laoreet. Proin placerat dui ex, id condimentum diam placerat in. Suspendisse imperdiet malesuada erat ullamcorper molestie. Nunc eu gravida felis. Vestibulum a mattis metus, eget lobortis ipsum. Sed ac hendrerit purus, eget sollicitudin justo. Cras mattis quam eros. Curabitur porta, libero et rhoncus viverra, elit ligula sagittis mi, ut elementum augue neque sed augue. Nam erat neque, gravida in tincidunt sed, porttitor a mi. Maecenas quis odio eget magna rhoncus cursus sed a mi. Mauris vehicula lacinia malesuada.\r\nPhasellus in sagittis ex. Donec in laoreet nulla, at tincidunt ligula. Ut porta, magna ultrices efficitur sodales, tellus mi efficitur enim, ut egestas felis massa non nunc. Donec posuere viverra faucibus. Aenean ultrices ante neque, non egestas erat varius in. Suspendisse at dolor bibendum, dapibus erat id, ornare felis. Nulla nisi nunc, accumsan sit amet placerat vitae, tempor id erat. Etiam id venenatis turpis, a consequat nisl. Suspendisse vitae ante in tortor fringilla ultrices eu et justo. Fusce vehicula at arcu vitae tempor. Sed rhoncus ex a quam suscipit, ut lobortis augue gravida. Integer turpis felis, consectetur sit amet malesuada ac, egestas eget elit. Fusce eget tortor ut massa venenatis bibendum nec ac nisl.\r\nVivamus turpis nibh, semper vel est at, molestie bibendum nibh. Integer dapibus nulla eu metus mattis, at porttitor sapien placerat. Vivamus ac sollicitudin urna. Vivamus eget dapibus augue. Cras placerat purus sit amet sem cursus, quis dictum ligula facilisis. Nulla ultrices feugiat lorem, nec dapibus elit congue nec. Sed cursus blandit lorem eget hendrerit. Donec tortor elit, euismod quis sagittis eget, fermentum eget dui.\r\nAenean vitae orci id arcu viverra lacinia. Pellentesque id convallis purus. Vestibulum quis malesuada nisi. Nam gravida ex vel malesuada gravida. Sed at lorem enim. Ut feugiat auctor scelerisque. Vestibulum laoreet vel purus eleifend consequat.", "klasslar-və-strukturalar", 3, "Klasslar və strukturalar", null, null },
                    { 5, 1, new DateTime(2024, 10, 4, 4, 41, 4, 860, DateTimeKind.Utc).AddTicks(1845), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu finibus lorem. Nulla consequat efficitur ex, sed finibus velit interdum sit amet. Sed ut quam augue. In in urna metus. Quisque dapibus nisi ut massa mattis, id commodo mauris posuere. Duis viverra finibus lorem, id ornare nisi malesuada vitae. Sed interdum lectus et nibh pretium tincidunt. Praesent pretium sapien at convallis lobortis. Fusce id venenatis magna. Proin fringilla orci turpis, a posuere sem pretium ac. Vestibulum malesuada, tortor ac pulvinar cursus, lectus magna volutpat augue, nec scelerisque dui risus vitae orci. \r\nQuisque justo urna, facilisis et euismod ut, cursus ac orci. Sed feugiat metus vitae massa dignissim, nec sagittis metus laoreet. Proin placerat dui ex, id condimentum diam placerat in. Suspendisse imperdiet malesuada erat ullamcorper molestie. Nunc eu gravida felis. Vestibulum a mattis metus, eget lobortis ipsum. Sed ac hendrerit purus, eget sollicitudin justo. Cras mattis quam eros. Curabitur porta, libero et rhoncus viverra, elit ligula sagittis mi, ut elementum augue neque sed augue. Nam erat neque, gravida in tincidunt sed, porttitor a mi. Maecenas quis odio eget magna rhoncus cursus sed a mi. Mauris vehicula lacinia malesuada.\r\nPhasellus in sagittis ex. Donec in laoreet nulla, at tincidunt ligula. Ut porta, magna ultrices efficitur sodales, tellus mi efficitur enim, ut egestas felis massa non nunc. Donec posuere viverra faucibus. Aenean ultrices ante neque, non egestas erat varius in. Suspendisse at dolor bibendum, dapibus erat id, ornare felis. Nulla nisi nunc, accumsan sit amet placerat vitae, tempor id erat. Etiam id venenatis turpis, a consequat nisl. Suspendisse vitae ante in tortor fringilla ultrices eu et justo. Fusce vehicula at arcu vitae tempor. Sed rhoncus ex a quam suscipit, ut lobortis augue gravida. Integer turpis felis, consectetur sit amet malesuada ac, egestas eget elit. Fusce eget tortor ut massa venenatis bibendum nec ac nisl.\r\nVivamus turpis nibh, semper vel est at, molestie bibendum nibh. Integer dapibus nulla eu metus mattis, at porttitor sapien placerat. Vivamus ac sollicitudin urna. Vivamus eget dapibus augue. Cras placerat purus sit amet sem cursus, quis dictum ligula facilisis. Nulla ultrices feugiat lorem, nec dapibus elit congue nec. Sed cursus blandit lorem eget hendrerit. Donec tortor elit, euismod quis sagittis eget, fermentum eget dui.\r\nAenean vitae orci id arcu viverra lacinia. Pellentesque id convallis purus. Vestibulum quis malesuada nisi. Nam gravida ex vel malesuada gravida. Sed at lorem enim. Ut feugiat auctor scelerisque. Vestibulum laoreet vel purus eleifend consequat.", "record-tipi", 3, "Record tipi", null, null },
                    { 6, 1, new DateTime(2024, 10, 4, 4, 41, 4, 860, DateTimeKind.Utc).AddTicks(1848), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu finibus lorem. Nulla consequat efficitur ex, sed finibus velit interdum sit amet. Sed ut quam augue. In in urna metus. Quisque dapibus nisi ut massa mattis, id commodo mauris posuere. Duis viverra finibus lorem, id ornare nisi malesuada vitae. Sed interdum lectus et nibh pretium tincidunt. Praesent pretium sapien at convallis lobortis. Fusce id venenatis magna. Proin fringilla orci turpis, a posuere sem pretium ac. Vestibulum malesuada, tortor ac pulvinar cursus, lectus magna volutpat augue, nec scelerisque dui risus vitae orci. \r\nQuisque justo urna, facilisis et euismod ut, cursus ac orci. Sed feugiat metus vitae massa dignissim, nec sagittis metus laoreet. Proin placerat dui ex, id condimentum diam placerat in. Suspendisse imperdiet malesuada erat ullamcorper molestie. Nunc eu gravida felis. Vestibulum a mattis metus, eget lobortis ipsum. Sed ac hendrerit purus, eget sollicitudin justo. Cras mattis quam eros. Curabitur porta, libero et rhoncus viverra, elit ligula sagittis mi, ut elementum augue neque sed augue. Nam erat neque, gravida in tincidunt sed, porttitor a mi. Maecenas quis odio eget magna rhoncus cursus sed a mi. Mauris vehicula lacinia malesuada.\r\nPhasellus in sagittis ex. Donec in laoreet nulla, at tincidunt ligula. Ut porta, magna ultrices efficitur sodales, tellus mi efficitur enim, ut egestas felis massa non nunc. Donec posuere viverra faucibus. Aenean ultrices ante neque, non egestas erat varius in. Suspendisse at dolor bibendum, dapibus erat id, ornare felis. Nulla nisi nunc, accumsan sit amet placerat vitae, tempor id erat. Etiam id venenatis turpis, a consequat nisl. Suspendisse vitae ante in tortor fringilla ultrices eu et justo. Fusce vehicula at arcu vitae tempor. Sed rhoncus ex a quam suscipit, ut lobortis augue gravida. Integer turpis felis, consectetur sit amet malesuada ac, egestas eget elit. Fusce eget tortor ut massa venenatis bibendum nec ac nisl.\r\nVivamus turpis nibh, semper vel est at, molestie bibendum nibh. Integer dapibus nulla eu metus mattis, at porttitor sapien placerat. Vivamus ac sollicitudin urna. Vivamus eget dapibus augue. Cras placerat purus sit amet sem cursus, quis dictum ligula facilisis. Nulla ultrices feugiat lorem, nec dapibus elit congue nec. Sed cursus blandit lorem eget hendrerit. Donec tortor elit, euismod quis sagittis eget, fermentum eget dui.\r\nAenean vitae orci id arcu viverra lacinia. Pellentesque id convallis purus. Vestibulum quis malesuada nisi. Nam gravida ex vel malesuada gravida. Sed at lorem enim. Ut feugiat auctor scelerisque. Vestibulum laoreet vel purus eleifend consequat.", "statik-klasslar", 3, "Statik klasslar", null, null },
                    { 7, 1, new DateTime(2024, 10, 4, 4, 41, 4, 860, DateTimeKind.Utc).AddTicks(1850), 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eu finibus lorem. Nulla consequat efficitur ex, sed finibus velit interdum sit amet. Sed ut quam augue. In in urna metus. Quisque dapibus nisi ut massa mattis, id commodo mauris posuere. Duis viverra finibus lorem, id ornare nisi malesuada vitae. Sed interdum lectus et nibh pretium tincidunt. Praesent pretium sapien at convallis lobortis. Fusce id venenatis magna. Proin fringilla orci turpis, a posuere sem pretium ac. Vestibulum malesuada, tortor ac pulvinar cursus, lectus magna volutpat augue, nec scelerisque dui risus vitae orci. \r\nQuisque justo urna, facilisis et euismod ut, cursus ac orci. Sed feugiat metus vitae massa dignissim, nec sagittis metus laoreet. Proin placerat dui ex, id condimentum diam placerat in. Suspendisse imperdiet malesuada erat ullamcorper molestie. Nunc eu gravida felis. Vestibulum a mattis metus, eget lobortis ipsum. Sed ac hendrerit purus, eget sollicitudin justo. Cras mattis quam eros. Curabitur porta, libero et rhoncus viverra, elit ligula sagittis mi, ut elementum augue neque sed augue. Nam erat neque, gravida in tincidunt sed, porttitor a mi. Maecenas quis odio eget magna rhoncus cursus sed a mi. Mauris vehicula lacinia malesuada.\r\nPhasellus in sagittis ex. Donec in laoreet nulla, at tincidunt ligula. Ut porta, magna ultrices efficitur sodales, tellus mi efficitur enim, ut egestas felis massa non nunc. Donec posuere viverra faucibus. Aenean ultrices ante neque, non egestas erat varius in. Suspendisse at dolor bibendum, dapibus erat id, ornare felis. Nulla nisi nunc, accumsan sit amet placerat vitae, tempor id erat. Etiam id venenatis turpis, a consequat nisl. Suspendisse vitae ante in tortor fringilla ultrices eu et justo. Fusce vehicula at arcu vitae tempor. Sed rhoncus ex a quam suscipit, ut lobortis augue gravida. Integer turpis felis, consectetur sit amet malesuada ac, egestas eget elit. Fusce eget tortor ut massa venenatis bibendum nec ac nisl.\r\nVivamus turpis nibh, semper vel est at, molestie bibendum nibh. Integer dapibus nulla eu metus mattis, at porttitor sapien placerat. Vivamus ac sollicitudin urna. Vivamus eget dapibus augue. Cras placerat purus sit amet sem cursus, quis dictum ligula facilisis. Nulla ultrices feugiat lorem, nec dapibus elit congue nec. Sed cursus blandit lorem eget hendrerit. Donec tortor elit, euismod quis sagittis eget, fermentum eget dui.\r\nAenean vitae orci id arcu viverra lacinia. Pellentesque id convallis purus. Vestibulum quis malesuada nisi. Nam gravida ex vel malesuada gravida. Sed at lorem enim. Ut feugiat auctor scelerisque. Vestibulum laoreet vel purus eleifend consequat.", "abstrakt-klasslar", 3, "Abstrakt klasslar", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_authors_creator_author_id",
                schema: "posts",
                table: "authors",
                column: "creator_author_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_creator_author_id",
                schema: "posts",
                table: "category",
                column: "creator_author_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_created_by",
                schema: "posts",
                table: "comments",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_comments_parent_id",
                schema: "posts",
                table: "comments",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_post_id",
                schema: "posts",
                table: "comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "ix_post_tag_tags_tag_id",
                schema: "posts",
                table: "post_tag",
                column: "tags_tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_posts_category_id",
                schema: "posts",
                table: "posts",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_posts_created_by",
                schema: "posts",
                table: "posts",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "ix_posts_parent_post_id",
                schema: "posts",
                table: "posts",
                column: "parent_post_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_created_by",
                schema: "posts",
                table: "tags",
                column: "created_by");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments",
                schema: "posts");

            migrationBuilder.DropTable(
                name: "post_tag",
                schema: "posts");

            migrationBuilder.DropTable(
                name: "posts",
                schema: "posts");

            migrationBuilder.DropTable(
                name: "tags",
                schema: "posts");

            migrationBuilder.DropTable(
                name: "category",
                schema: "posts");

            migrationBuilder.DropTable(
                name: "authors",
                schema: "posts");
        }
    }
}
