using AutoMapper;
using FS.EAuctions.Application.Bids.Get;

namespace FS.EAuctions.Application.Profiles.Bid;

public class SupplierBidToSupplierBidDtoProfile : Profile
{
    public SupplierBidToSupplierBidDtoProfile()
    {
        CreateMap<Domain.Bids.SupplierBid, SupplierBidDto>();
    }
}
