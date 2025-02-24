using System.Runtime.Serialization;

namespace FS.EAuctions.Application.Bids.Get;

[DataContract]
public record SupplierBidDto(Guid Id, string Name, int Quantity, string? Unit);