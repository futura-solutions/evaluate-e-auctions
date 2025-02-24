using FS.EAuctions.Data.DBContexts;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using Microsoft.EntityFrameworkCore;

namespace FS.EAuctions.Data.Repository;

public class BuyerAuctionRepository : IAuctionRepository<BuyerAuction, BuyerBid>
{
    private readonly AuctionDbContext _buyerAuctionDbContext;
    
    public BuyerAuctionRepository(AuctionDbContext buyerAuctionDbContext)
    {
        _buyerAuctionDbContext = buyerAuctionDbContext;
    }
    
    public async Task<bool> ExistsAsync(Guid auctionId)
    {
        return await _buyerAuctionDbContext.BuyerAuctions.AnyAsync(r => r.Id == auctionId);
    }
    
    public async Task<BuyerAuction> GetAuctionAsync(Guid supplierAuctionId, bool includeBids)
    {
        if (includeBids)
        {
            return (await _buyerAuctionDbContext.BuyerAuctions
                .Include(ba => ba.BuyerBids)
                .Where(ba => ba.Id == supplierAuctionId).FirstOrDefaultAsync())!;
        }

        return (await _buyerAuctionDbContext.BuyerAuctions
            .Where(r => r.Id == supplierAuctionId).FirstOrDefaultAsync())!;
    }

    public async Task AddBidToAuctionAsync(Guid buyerAuctionId, BuyerBid buyerBid)
    {
        var buyerAuction = await GetAuctionAsync(buyerAuctionId, false);
        if(buyerAuction != null)
        {
            buyerAuction.BuyerBids.Add(buyerBid);
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _buyerAuctionDbContext.SaveChangesAsync() >= 0);
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

    public async Task<bool> AuctionExistsAsync(Guid buyerAuctionId)
    {
        return await _buyerAuctionDbContext.BuyerAuctions.AnyAsync(r => r.Id == buyerAuctionId);
    }
}
