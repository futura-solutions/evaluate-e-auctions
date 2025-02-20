using System.Runtime.Serialization;

namespace FS.EAuctions.Application.Bids.Get;

[DataContract]
public record BidDto(Guid Id, string Name, int Quantity, string? Unit);