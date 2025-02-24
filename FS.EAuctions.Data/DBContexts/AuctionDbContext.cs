using FS.EAuctions.Data.Base;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using Microsoft.EntityFrameworkCore;

namespace FS.EAuctions.Data.DBContexts;

public class AuctionDbContext : AuditableModelDbContextBase
{
    public DbSet<BuyerAuction> BuyerAuctions { get; set; }
    public DbSet<SupplierAuction> SupplierAuctions { get; set; }
    
    public DbSet<SupplierBid> SupplierBids { get; set; }
    public DbSet<BuyerBid> BuyerBids { get; set; }

    public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuctionDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
