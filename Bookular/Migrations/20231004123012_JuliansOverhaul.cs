using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookular.Migrations
{
    /// <inheritdoc />
    public partial class JuliansOverhaul : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Bio",
                value: "Tess Gerritsen left a successful practice as an internist to raise her children and concentrate on her writing.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Bio",
                value: "Nicole Fox is the New York Times bestselling author of numerous historical romances.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Bio",
                value: "Tess Gerritsen left a successful practice as an internist to raise her children and concentrate on her writing. She gained nationwide acclaim for her first novel of medical suspense, the New York Times bestseller Harvest; she followed her debut with the bestsellers Life Support and Gravity (both available from Pocket Books.) Her other novels includes Body Double, The Sinner, The Apprentice, and The Surgeon. Tess Gerritsen lives in Maine.");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Bio",
                value: "Nicole Fox is the New York Times bestselling author of numerous historical romances. She lives with her real-life hero (her husband) in the Rocky Mountains of Utah, where she is at work on her next enthralling tale about the sparks that fly when Regency lovers play the matrimonial mating game.");
        }
    }
}
