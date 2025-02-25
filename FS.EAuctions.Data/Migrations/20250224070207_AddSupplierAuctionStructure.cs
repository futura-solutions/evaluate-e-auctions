using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS.EAuctions.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSupplierAuctionStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerBids_BuyerAuction_AuctionId",
                table: "BuyerBids");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierBids_SupplierAuction_AuctionId",
                table: "SupplierBids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierAuction",
                table: "SupplierAuction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyerAuction",
                table: "BuyerAuction");

            migrationBuilder.RenameTable(
                name: "SupplierAuction",
                newName: "SupplierAuctions");

            migrationBuilder.RenameTable(
                name: "BuyerAuction",
                newName: "BuyerAuctions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierAuctions",
                table: "SupplierAuctions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyerAuctions",
                table: "BuyerAuctions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerBids_BuyerAuctions_AuctionId",
                table: "BuyerBids",
                column: "AuctionId",
                principalTable: "BuyerAuctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierBids_SupplierAuctions_AuctionId",
                table: "SupplierBids",
                column: "AuctionId",
                principalTable: "SupplierAuctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerBids_BuyerAuctions_AuctionId",
                table: "BuyerBids");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierBids_SupplierAuctions_AuctionId",
                table: "SupplierBids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierAuctions",
                table: "SupplierAuctions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyerAuctions",
                table: "BuyerAuctions");

            migrationBuilder.RenameTable(
                name: "SupplierAuctions",
                newName: "SupplierAuction");

            migrationBuilder.RenameTable(
                name: "BuyerAuctions",
                newName: "BuyerAuction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierAuction",
                table: "SupplierAuction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyerAuction",
                table: "BuyerAuction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerBids_BuyerAuction_AuctionId",
                table: "BuyerBids",
                column: "AuctionId",
                principalTable: "BuyerAuction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierBids_SupplierAuction_AuctionId",
                table: "SupplierBids",
                column: "AuctionId",
                principalTable: "SupplierAuction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
