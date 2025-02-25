using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS.EAuctions.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToAuction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SupplierAuction",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BuyerAuction",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SupplierAuction");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BuyerAuction");
        }
    }
}
