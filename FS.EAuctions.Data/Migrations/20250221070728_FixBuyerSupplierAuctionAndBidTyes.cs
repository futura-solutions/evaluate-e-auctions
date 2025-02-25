using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS.EAuctions.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixBuyerSupplierAuctionAndBidTyes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_SupplierAuction_AuctionId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyerBid_BuyerAuction_AuctionId",
                table: "BuyerBid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyerBid",
                table: "BuyerBid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bids",
                table: "Bids");

            migrationBuilder.RenameTable(
                name: "BuyerBid",
                newName: "BuyerBids");

            migrationBuilder.RenameTable(
                name: "Bids",
                newName: "SupplierBids");

            migrationBuilder.RenameIndex(
                name: "IX_BuyerBid_AuctionId",
                table: "BuyerBids",
                newName: "IX_BuyerBids_AuctionId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_AuctionId",
                table: "SupplierBids",
                newName: "IX_SupplierBids_AuctionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyerBids",
                table: "BuyerBids",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierBids",
                table: "SupplierBids",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerBids_BuyerAuction_AuctionId",
                table: "BuyerBids");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierBids_SupplierAuction_AuctionId",
                table: "SupplierBids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierBids",
                table: "SupplierBids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyerBids",
                table: "BuyerBids");

            migrationBuilder.RenameTable(
                name: "SupplierBids",
                newName: "Bids");

            migrationBuilder.RenameTable(
                name: "BuyerBids",
                newName: "BuyerBid");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierBids_AuctionId",
                table: "Bids",
                newName: "IX_Bids_AuctionId");

            migrationBuilder.RenameIndex(
                name: "IX_BuyerBids_AuctionId",
                table: "BuyerBid",
                newName: "IX_BuyerBid_AuctionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bids",
                table: "Bids",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyerBid",
                table: "BuyerBid",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_SupplierAuction_AuctionId",
                table: "Bids",
                column: "AuctionId",
                principalTable: "SupplierAuction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerBid_BuyerAuction_AuctionId",
                table: "BuyerBid",
                column: "AuctionId",
                principalTable: "BuyerAuction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
