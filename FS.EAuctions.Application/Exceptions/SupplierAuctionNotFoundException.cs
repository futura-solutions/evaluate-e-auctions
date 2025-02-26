namespace FS.EAuctions.Application.Exceptions;
[Serializable]
public class SupplierAuctionNotFoundException : Exception
{
    public SupplierAuctionNotFoundException(Guid supplierAuctionId) : base($"The supplier auction with id {supplierAuctionId} was not found!")
    {
    }
}