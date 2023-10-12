using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookular.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePriceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"
        CREATE PROCEDURE UpdateBookPricesByPercentage
            @percentage int
        AS
        BEGIN
            SET NOCOUNT ON;
            UPDATE Books
            SET Price = Price + (Price * @percentage / 100)
        END";

            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE UpdateBookPricesByPercentage");
        }
    }
}
