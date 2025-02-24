using FS.EAuctions.Application.BuyerAuctions.Create;
using FS.EAuctions.Application.BuyerAuctions.Get;
using MediatR;

namespace FS.EAuctions.Application.SupplierAuctions.Create;

public class CreateSupplierAuctionCommand : IRequest<SupplierAuctionDto>
{
	public SupplierAuctionForCreationDto SupplierAuctionForCreationDto { get; set; }
	public Guid UserId { get; }

	public CreateSupplierAuctionCommand(SupplierAuctionForCreationDto supplierAuctionForCreationDto, Guid userId)
	{
		SupplierAuctionForCreationDto = supplierAuctionForCreationDto;
		UserId = userId;
	}
}