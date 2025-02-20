using FS.EAuctions.Application.Bids.Create;

namespace FS.EAuctions.Application.BuyerAuctions.Create;

public record BuyerAuctionForCreationDto(string Name, string Description, IEnumerable<BidForCreationDto> Bids, Guid CreatedBy);