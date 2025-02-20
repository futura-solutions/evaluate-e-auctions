using FS.EAuctions.Application.BuyerAuctions.Get;
using MediatR;

namespace FS.EAuctions.Application.BuyerAuctions.Create;

public class CreateBuyerAuctionCommand : IRequest<BuyerAuctionDto>
{
	public BuyerAuctionForCreationDto BuyerAuctionForCreationDto { get; set; }
	public Guid UserId { get; }

	public CreateBuyerAuctionCommand(BuyerAuctionForCreationDto buyerAuctionForCreationDto, Guid userId)
	{
		BuyerAuctionForCreationDto = buyerAuctionForCreationDto;
		UserId = userId;
	}
}