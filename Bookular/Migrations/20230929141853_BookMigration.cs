using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookular.Migrations
{
    /// <inheritdoc />
    public partial class BookMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1L, "Has pricey books", "Mark J.", "Price" },
                    { 2L, "Robert Cecil Martin (born 5 December 1952), colloquially called", "Robert C.", "Martin" },
                    { 3L, "Count Lev Nikolayevich Tolstoy, usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time.", "Leo", "Tolstoy" },
                    { 4L, "Jerome David Salinger was an American writer best known for his novel The Catcher in the Rye.", "J.D.", "Salinger" },
                    { 5L, "Francis Scott Key Fitzgerald was an American novelist, essayist, screenwriter, and short-story writer.", "F. Scott", "Fitzgerald" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "AuthorName", "Description", "Title" },
                values: new object[,]
                {
                    { 55L, 1L, "Mark J. Price", "The epic tale of love and loss set during the war between Russia and France.", "War and Peace" },
                    { 66L, 2L, "Robert C. Martin", "Holden Caulfield's journey through New York City and the loss of his innocence.", "The Catcher in the Rye" },
                    { 5757L, 3L, "Leo Tolstoy", "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan.", "Design patterns" },
                    { 65433L, 5L, "F. Scott Fitzgerald", "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan", "C# 10 in a Nutshell" },
                    { 322343L, 4L, "J.D. Salinger", "Count Lev Nikolayevich Tolstoy, usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time.", "C# 11 and .NET 7 – Modern Cross-Platform" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
