﻿// <auto-generated />
using System;
using FS.EAuctions.Data.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FS.EAuctions.Data.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    [Migration("20250221070728_FixBuyerSupplierAuctionAndBidTyes")]
    partial class FixBuyerSupplierAuctionAndBidTyes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FS.EAuctions.Domain.Auctions.BuyerAuction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("EndAuctionDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<DateTimeOffset>("StartAuctionDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("BuyerAuction");
                });

            modelBuilder.Entity("FS.EAuctions.Domain.Auctions.SupplierAuction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("EndAuctionDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<DateTimeOffset>("StartAuctionDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("SupplierAuction");
                });

            modelBuilder.Entity("FS.EAuctions.Domain.Bids.BuyerBid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuctionId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("ReceivedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("BuyerBids");
                });

            modelBuilder.Entity("FS.EAuctions.Domain.Bids.SupplierBid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuctionId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("ReceivedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("SupplierBids");
                });

            modelBuilder.Entity("FS.EAuctions.Domain.Bids.BuyerBid", b =>
                {
                    b.HasOne("FS.EAuctions.Domain.Auctions.BuyerAuction", "Auction")
                        .WithMany("BuyerBids")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");
                });

            modelBuilder.Entity("FS.EAuctions.Domain.Bids.SupplierBid", b =>
                {
                    b.HasOne("FS.EAuctions.Domain.Auctions.SupplierAuction", "Auction")
                        .WithMany("SupplierBids")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");
                });

            modelBuilder.Entity("FS.EAuctions.Domain.Auctions.BuyerAuction", b =>
                {
                    b.Navigation("BuyerBids");
                });

            modelBuilder.Entity("FS.EAuctions.Domain.Auctions.SupplierAuction", b =>
                {
                    b.Navigation("SupplierBids");
                });
#pragma warning restore 612, 618
        }
    }
}
