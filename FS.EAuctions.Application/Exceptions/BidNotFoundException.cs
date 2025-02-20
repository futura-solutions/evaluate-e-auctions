namespace FS.EAuctions.Application.Exceptions;
[Serializable]
public class BidNotFoundException : Exception
{
    public BidNotFoundException(Guid bidId) : base($"The bid with id {bidId} was not found!")
    {
    }
}