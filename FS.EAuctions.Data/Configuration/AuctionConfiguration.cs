using FS.EAuctions.Domain.Auctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FS.EAuctions.Data.Configuration;

internal class AuctionConfiguration : IEntityTypeConfiguration<BuyerAuction>
{
    public void Configure(EntityTypeBuilder<BuyerAuction> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .HasMaxLength(80)
            .IsRequired();
        
        builder.HasMany(r => r.Bids)
            .WithOne(i => i.Auction)
            .HasForeignKey(i => i.AuctionId);
    }
}
