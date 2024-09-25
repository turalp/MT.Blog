using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
