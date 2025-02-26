using FS.EAuctions.Data.DBContexts;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using Microsoft.EntityFrameworkCore;

namespace FS.EAuctions.Data.Repository;

public class SupplierAuctionRepository : IAuctionRepository<SupplierAuction, SupplierBid>
{
    private readonly AuctionDbContext _supplierAuctionDbContext;
    
    public SupplierAuctionRepository(AuctionDbContext supplierAuctionDbContext)
    {
        _supplierAuctionDbContext = supplierAuctionDbContext;
    }

    public Task AddBidToAuctionAsync(Guid auctionId, BuyerBid buyerBid)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(Guid auctionId)
    {
        return await _supplierAuctionDbContext.SupplierAuctions.AnyAsync(r => r.Id == auctionId);
    }
    
    public async Task<SupplierAuction> GetAuctionAsync(Guid supplierAuctionId, bool includeBids)
    {
        if (includeBids)
        {
            return (await _supplierAuctionDbContext.SupplierAuctions
                .Include(ba => ba.SupplierBids)
                .Where(ba => ba.Id == supplierAuctionId).FirstOrDefaultAsync())!;
        }

        return (await _supplierAuctionDbContext.SupplierAuctions
            .Where(r => r.Id == supplierAuctionId).FirstOrDefaultAsync())!;
    }

    public async Task AddBidToAuctionAsync(Guid supplierAuctionId, SupplierBid supplierBid)
    {
        var supplierAuction = await GetAuctionAsync(supplierAuctionId, false);
        supplierAuction.SupplierBids.Add(supplierBid);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _supplierAuctionDbContext.SaveChangesAsync() >= 0);
    }

    public Task<SupplierBid> GetBidForAuctionAsync(Guid requestBidId, Guid bidId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> BidExistsAsync(Guid requestAuctionId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SupplierBid>> GetBidsForAuctionAsync(Guid auctionId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AuctionExistsAsync(Guid auctionId)
    {
        return await _supplierAuctionDbContext.SupplierAuctions.AnyAsync(r => r.Id == auctionId);
    }
}
