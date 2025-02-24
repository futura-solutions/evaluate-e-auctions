using AutoMapper;
using FS.EAuctions.Application.Bids.Create;
using FS.EAuctions.Application.Bids.Get;

namespace FS.EAuctions.Application.Profiles.Bid;

public class SupplierBidForCreationDtoToBidProfile : Profile
{
    public SupplierBidForCreationDtoToBidProfile()
    {
        CreateMap<SupplierBidForCreationDto, Domain.Bids.SupplierBid>()
            .ForMember(dest => dest.Auction, opts => opts.Ignore())
            .ForMember(dest => dest.AuctionId, opts => opts.Ignore())
            .ForMember(dest => dest.Id, opts => opts.Ignore());

        CreateMap<Domain.Bids.SupplierBid, SupplierBidDto>();
    }
}
