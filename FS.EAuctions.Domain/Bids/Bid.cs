using System.Security.AccessControl;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Base;
using Microsoft.Extensions.ObjectPool;

namespace FS.EAuctions.Domain.Bids;

public class Bid : BaseEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; private set; } = String.Empty;

    public int Quantity { get; private set; }

    public string Unit { get; private set; }  = String.Empty;
    
    public BuyerAuction Auction { get; set; }

    public Guid AuctionId { get; set; }

    public DateTimeOffset ReceivedAt { get; set; }
}