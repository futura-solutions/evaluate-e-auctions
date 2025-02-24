using FS.EAuctions.Domain.Auctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FS.EAuctions.Data.Configuration;

internal class SupplierAuctionConfiguration : IEntityTypeConfiguration<SupplierAuction>
{
    public void Configure(EntityTypeBuilder<SupplierAuction> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .HasMaxLength(80)
            .IsRequired();
        
        builder.HasMany(r => r.SupplierBids)
            .WithOne(i => i.Auction)
            .HasForeignKey(i => i.AuctionId);
    }
}
