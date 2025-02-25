using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS.EAuctions.Data.Migrations
{
    /// <inheritdoc />
    public partial class BuyerSupplierAuctionAndBidTyes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_BuyerAuctions_AuctionId",
                table: "Bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyerAuctions",
                table: "BuyerAuctions");

            migrationBuilder.RenameTable(
                name: "BuyerAuctions",
                newName: "BuyerAuction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyerAuction",
                table: "BuyerAuction",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BuyerBid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    AuctionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceivedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerBid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyerBid_BuyerAuction_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "BuyerAuction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierAuction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartAuctionDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndAuctionDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierAuction", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerBid_AuctionId",
                table: "BuyerBid",
                column: "AuctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_SupplierAuction_AuctionId",
                table: "Bids",
                column: "AuctionId",
                principalTable: "SupplierAuction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_SupplierAuction_AuctionId",
                table: "Bids");

            migrationBuilder.DropTable(
                name: "BuyerBid");

            migrationBuilder.DropTable(
                name: "SupplierAuction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyerAuction",
                table: "BuyerAuction");

            migrationBuilder.RenameTable(
                name: "BuyerAuction",
                newName: "BuyerAuctions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyerAuctions",
                table: "BuyerAuctions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_BuyerAuctions_AuctionId",
                table: "Bids",
                column: "AuctionId",
                principalTable: "BuyerAuctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
