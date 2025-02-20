using FS.EAuctions.Data.DBContexts;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using Microsoft.EntityFrameworkCore;

namespace FS.EAuctions.Data.Repository;

public class BuyerAuctionRepository : IBuyerAuctionRepository
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
    
    public async Task<BuyerAuction> GetBuyerAuctionAsync(Guid buyerAuctionId, bool includeBids)
    {
        if (includeBids)
        {
            return (await _buyerAuctionDbContext.BuyerAuctions
                .Include(ba => ba.Bids)
                .Where(ba => ba.Id == buyerAuctionId).FirstOrDefaultAsync())!;
        }

        return (await _buyerAuctionDbContext.BuyerAuctions
            .Where(r => r.Id == buyerAuctionId).FirstOrDefaultAsync())!;
    }

    public async Task AddBidToAuctionAsync(Guid buyerAuctionId, Bid bid)
    {
        var buyerAuction = await GetBuyerAuctionAsync(buyerAuctionId, false);
        if(buyerAuction != null)
        {
            buyerAuction.Bids.Add(bid);
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _buyerAuctionDbContext.SaveChangesAsync() >= 0);
    }

    public Task<Bid> GetBidForAuctionAsync(Guid requestBidId, Guid bidId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> BidExistsAsync(Guid requestAuctionId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Bid>> GetBidsForAuctionAsync(Guid auctionId)
    {
        throw new NotImplementedException();
    }
}
