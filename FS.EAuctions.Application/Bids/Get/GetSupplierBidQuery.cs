using MediatR;

namespace FS.EAuctions.Application.Bids.Get;

public class GetSupplierBidQuery : IRequest<SupplierBidDto>
{
	public Guid BuyerAuctionId { get; set; }
	public Guid BidId { get; set; }

	public GetSupplierBidQuery(Guid buyerAuctionId, Guid bidId)
	{
		BuyerAuctionId = buyerAuctionId;
		BidId = bidId;
	}
}