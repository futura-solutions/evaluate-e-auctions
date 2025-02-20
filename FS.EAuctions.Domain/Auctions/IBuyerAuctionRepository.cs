using FS.EAuctions.Domain.Bids;

namespace FS.EAuctions.Domain.Auctions;

public interface IBuyerAuctionRepository
{
    Task<BuyerAuction> GetBuyerAuctionAsync(Guid buyerAuctionId, bool includeBids);
    Task AddBidToAuctionAsync(Guid buyerAuctionId, Bid bid);
    Task<bool> ExistsAsync(Guid auctionId);
    Task<bool> SaveChangesAsync();
    Task<Bid> GetBidForAuctionAsync(Guid requestBidId, Guid bidId);
    Task<bool> BidExistsAsync(Guid requestAuctionId);
    Task<IEnumerable<Bid>> GetBidsForAuctionAsync(Guid auctionId);
}