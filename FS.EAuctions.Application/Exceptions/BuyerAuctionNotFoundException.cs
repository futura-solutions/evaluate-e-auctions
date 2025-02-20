namespace FS.EAuctions.Application.Exceptions;
[Serializable]
public class BuyerAuctionNotFoundException : Exception
{
    public BuyerAuctionNotFoundException(Guid auctionId) : base($"The bid with id {auctionId} was not found!")
    {
    }
}