using FS.EAuctions.Application.Bids.Create;

namespace FS.EAuctions.Application.BuyerAuctions.Create;

public record SupplierAuctionForCreationDto(
    string Name,
    DateTimeOffset StartAuctionDateTime,
    DateTimeOffset EndAuctionDateTime,
    string Description, 
    Guid CreatedBy);