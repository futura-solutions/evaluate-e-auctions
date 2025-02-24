using MediatR;

namespace FS.EAuctions.Application.BuyerAuctions.Get;

public class GetBuyerAuctionByIdQuery : IRequest<BuyerAuctionDto>
{
	public Guid BuyerAuctionId { get; set; }

	public GetBuyerAuctionByIdQuery(Guid buyerAuctionId)
	{
		BuyerAuctionId = buyerAuctionId;
	}
}