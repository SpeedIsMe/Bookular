using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookular.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    CREATE TRIGGER before_book_update 
    ON Books
    AFTER UPDATE
    AS
    BEGIN
        IF UPDATE(Price)
        BEGIN
            INSERT INTO BookHistories (BookId, OldPrice, DateChanged) 
            SELECT d.Id, d.Price, GETDATE()
            FROM deleted d
        END
    END;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER before_book_update");
        }
    }
}
