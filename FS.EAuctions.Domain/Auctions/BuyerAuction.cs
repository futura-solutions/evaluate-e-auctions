using FS.EAuctions.Domain.Base;
using FS.EAuctions.Domain.Bids;

namespace FS.EAuctions.Domain.Auctions;

public class BuyerAuction : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Bid> Bids { get; private set; } = new List<Bid>();
}