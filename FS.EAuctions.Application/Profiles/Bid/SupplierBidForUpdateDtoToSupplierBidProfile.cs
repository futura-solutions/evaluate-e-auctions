using AutoMapper;
using FS.EAuctions.Application.Bids.Update;

namespace FS.EAuctions.Application.Profiles.Bid;

public class SupplierBidForUpdateDtoToSupplierBidProfile : Profile
{
    public SupplierBidForUpdateDtoToSupplierBidProfile()
    {
        CreateMap<SupplierBidForUpdateDto, Domain.Bids.SupplierBid>()
            .ForMember(dest => dest.Auction, opts => opts.Ignore())
            .ForMember(dest => dest.AuctionId, opts => opts.Ignore())
            .ForMember(dest => dest.Id, opts => opts.Ignore());
    }
}
