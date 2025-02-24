using System.ComponentModel;
using FS.EAuctions.Domain.Base;
using FS.EAuctions.Domain.Bids;

namespace FS.EAuctions.Domain.Auctions;

public class BuyerAuction : BaseEntity
{
    public Guid Id { get; set; }

    
    public DateTimeOffset StartAuctionDateTime { get; set; }
    public DateTimeOffset EndAuctionDateTime { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = String.Empty;
    public ICollection<BuyerBid> BuyerBids { get; private set; } = new List<BuyerBid>();
}