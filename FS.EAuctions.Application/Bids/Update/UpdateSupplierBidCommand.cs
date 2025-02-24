using FS.EAuctions.Application.Bids.Update;
using MediatR;

namespace FS.EAuctions.Application.Bid.Update;

public class UpdateSupplierBidCommand : IRequest
{
    public SupplierBidForUpdateDto SupplierBidForUpdateDto { get; set; }
    public Guid AuctionId { get; set; }
    public Guid BidId { get; set; }

    public UpdateSupplierBidCommand(Guid auctionId, Guid bidId, SupplierBidForUpdateDto supplierBidForUpdateDto)
    {
        SupplierBidForUpdateDto = supplierBidForUpdateDto;
        AuctionId = auctionId;
        BidId = bidId;
    }
}

