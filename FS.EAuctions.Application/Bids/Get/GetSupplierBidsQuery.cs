using MediatR;

namespace FS.EAuctions.Application.Bids.Get;

public class GetSupplierBidsQuery: IRequest<IEnumerable<SupplierBidDto>>
{
    public Guid AuctionId { get; set; }

    public GetSupplierBidsQuery(Guid recipeId)
    {
        AuctionId = recipeId;
    }

}
