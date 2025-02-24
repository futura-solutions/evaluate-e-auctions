using FS.EAuctions.Application.Bids.Get;
using MediatR;

namespace FS.EAuctions.Application.Bids.Create;

public class CreateSupplierBidCommand : IRequest<SupplierBidDto>
{
    public SupplierBidForCreationDto SupplierBidForCreationDto { get; set; }
    public Guid BuyerAuctionId { get; set; }
    
    public DateTimeOffset ReceivedAt { get; set; }

    public CreateSupplierBidCommand(Guid buyerAuctionId, SupplierBidForCreationDto supplierBidForCreationDto, DateTime receivedAt)
    {
        SupplierBidForCreationDto = supplierBidForCreationDto;
        BuyerAuctionId = buyerAuctionId;
        ReceivedAt = receivedAt;
    }
}

