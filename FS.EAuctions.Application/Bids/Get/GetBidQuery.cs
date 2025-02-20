using MediatR;

namespace FS.EAuctions.Application.Bids.Get;

public class GetBidQuery : IRequest<BidDto>
{
	public Guid BuyerAuctionId { get; set; }
	public Guid BidId { get; set; }

	public GetBidQuery(Guid buyerAuctionId, Guid bidId)
	{
		BuyerAuctionId = buyerAuctionId;
		BidId = bidId;
	}
}