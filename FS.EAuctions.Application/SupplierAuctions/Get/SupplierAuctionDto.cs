using System.Runtime.Serialization;
using FS.EAuctions.Application.Bids.Get;

namespace FS.EAuctions.Application.BuyerAuctions.Get;

public record SupplierAuctionDto
{
    public SupplierAuctionDto() { } // Parameterless constructor required by AutoMapper

    public SupplierAuctionDto(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    
    public DateTimeOffset StartAuctionDateTime { get; set; }
    public DateTimeOffset EndAuctionDateTime { get; set; }
}

