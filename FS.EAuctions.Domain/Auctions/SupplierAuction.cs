using FS.EAuctions.Domain.Bids;

namespace FS.EAuctions.Domain.Auctions;

public class SupplierAuction
{
    public Guid Id { get; set; }
    
    public DateTimeOffset StartAuctionDateTime { get; set; }
    public DateTimeOffset EndAuctionDateTime { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = String.Empty;
    public ICollection<SupplierBid> SupplierBids { get; private set; } = new List<SupplierBid>();
}