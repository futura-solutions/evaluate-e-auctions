using FS.EAuctions.Domain.Bids;

namespace FS.EAuctions.Domain.Auctions;

public interface IAuctionRepository<TAuctionType,TBidType>
{
    Task<TAuctionType> GetAuctionAsync(Guid auctionId, bool includeBids);
    Task AddBidToAuctionAsync(Guid auctionId, TBidType buyerBid);
    Task<bool> ExistsAsync(Guid auctionId);
    Task<bool> SaveChangesAsync();
    Task<SupplierBid> GetBidForAuctionAsync(Guid requestBidId, Guid bidId);
    Task<bool> BidExistsAsync(Guid requestAuctionId);
    Task<IEnumerable<SupplierBid>> GetBidsForAuctionAsync(Guid auctionId);
    Task<bool> AuctionExistsAsync(Guid auctionId);
}