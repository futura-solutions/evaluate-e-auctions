using FS.EAuctions.Application.Bids.Get;
using MediatR;

namespace FS.EAuctions.Application.Bids.Create;

public class CreateBidCommand : IRequest<BidDto>
{
    public BidForCreationDto BidForCreationDto { get; set; }
    public Guid BuyerAuctionId { get; set; }
    
    public DateTimeOffset ReceivedAt { get; set; }

    public CreateBidCommand(Guid buyerAuctionId, BidForCreationDto bidForCreationDto, DateTime receivedAt)
    {
        BidForCreationDto = bidForCreationDto;
        BuyerAuctionId = buyerAuctionId;
        ReceivedAt = receivedAt;
    }
}

