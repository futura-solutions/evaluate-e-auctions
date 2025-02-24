﻿using FS.EAuctions.Domain.Bids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FS.EAuctions.Data.Configuration;

internal class BidConfiguration : IEntityTypeConfiguration<SupplierBid>
{
    public void Configure(EntityTypeBuilder<SupplierBid> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(i => i.Quantity)
            .IsRequired();

        builder.Property(i => i.Unit)
            .IsRequired();
    }
}
