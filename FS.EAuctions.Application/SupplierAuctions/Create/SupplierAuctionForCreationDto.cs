namespace FS.EAuctions.Application.SupplierAuctions.Create;

public record SupplierAuctionForCreationDto(
    string Name,
    DateTimeOffset StartAuctionDateTime,
    DateTimeOffset EndAuctionDateTime,
    string Description, 
    Guid CreatedBy);