using System.Runtime.Serialization;
using FS.EAuctions.Application.Bids.Get;

namespace FS.EAuctions.Application.BuyerAuctions.Get;

[DataContract]
public record BuyerAuctionDto(Guid Id, string? Name, string? Description, ICollection<BidDto> Bids)
{
    [DataMember]
    public int NumberOfBids => Bids.Count;
}
