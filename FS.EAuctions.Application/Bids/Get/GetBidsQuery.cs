using MediatR;

namespace FS.EAuctions.Application.Bids.Get;

public class GetBidsQuery: IRequest<IEnumerable<BidDto>>
{
    public Guid AuctionId { get; set; }

    public GetBidsQuery(Guid recipeId)
    {
        AuctionId = recipeId;
    }

}
