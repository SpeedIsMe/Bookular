using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookular.Migrations
{
    /// <inheritdoc />
    public partial class updateSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 5L, "Tess Gerritsen left a successful practice as an internist to raise her children and concentrate on her writing. She gained nationwide acclaim for her first novel of medical suspense, the New York Times bestseller Harvest; she followed her debut with the bestsellers Life Support and Gravity (both available from Pocket Books.) Her other novels includes Body Double, The Sinner, The Apprentice, and The Surgeon. Tess Gerritsen lives in Maine.", "Tess", "Gerritsen" },
                    { 6L, "Nicole Fox is the New York Times bestselling author of numerous historical romances. She lives with her real-life hero (her husband) in the Rocky Mountains of Utah, where she is at work on her next enthralling tale about the sparks that fly when Regency lovers play the matrimonial mating game.", "Nicole", "Fox" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AuthorId", "Description", "Title" },
                values: new object[] { 5L, "A retired CIA operative in small-town Maine tackles the ghosts of her past in this fresh take on the spy thriller from New York Times bestselling author Tess Gerritsen.", "The Spy Coast: A Thriller" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AuthorId", "Description", "Title" },
                values: new object[] { 6L, "Jane Doe lives in the shadows under an assumed name. A once-promising anthropologist and an expert on shamanism, everyone thinks she’s dead. Or so she hopes.", "Cruel Paradise" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 65433L,
                column: "Description",
                value: "When you have questions about how to use C# 10, this highly acclaimed bestseller has precisely the answers you need. Uniquely organized around concepts and use cases, this updated sixth edition includes completely revised and updated information on all the new C# 10 language features.");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 322343L,
                column: "Description",
                value: "An accessible guide for beginner-to-intermediate programmers to concepts, real-world applications, and latest features of C# 11 and .NET 7.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AuthorId", "Description", "Title" },
                values: new object[] { 1L, "Hamlet book", "Hamlet" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AuthorId", "Description", "Title" },
                values: new object[] { 1L, "King lear book", "King Lear" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 65433L,
                column: "Description",
                value: "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 322343L,
                column: "Description",
                value: "Count Lev Nikolayevich Tolstoy, usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time.");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[] { 3L, 1L, "Othello book", "Othello" });
        }
    }
}
