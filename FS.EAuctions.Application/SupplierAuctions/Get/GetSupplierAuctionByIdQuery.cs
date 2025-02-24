using FS.EAuctions.Application.BuyerAuctions.Get;
using MediatR;

namespace FS.EAuctions.Application.SupplierAuctions.Get;

public class GetSupplierAuctionByIdQuery : IRequest<SupplierAuctionDto>
{
	public Guid SupplierAuctionId { get; set; }

	public GetSupplierAuctionByIdQuery(Guid supplierAuctionId)
	{
		SupplierAuctionId = supplierAuctionId;
	}
}