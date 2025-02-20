using FS.EAuctions.Application.Bids.Update;
using MediatR;

namespace FS.EAuctions.Application.Bid.Update;

public class UpdateBidCommand : IRequest
{
    public BidForUpdateDto BidForUpdateDto { get; set; }
    public Guid AuctionId { get; set; }
    public Guid BidId { get; set; }

    public UpdateBidCommand(Guid auctionId, Guid bidId, BidForUpdateDto bidForUpdateDto)
    {
        BidForUpdateDto = bidForUpdateDto;
        AuctionId = auctionId;
        BidId = bidId;
    }
}

