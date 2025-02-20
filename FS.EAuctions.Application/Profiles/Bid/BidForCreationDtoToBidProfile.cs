using AutoMapper;
using FS.EAuctions.Application.Bids.Create;
using FS.EAuctions.Application.Bids.Get;

namespace FS.EAuctions.Application.Profiles.Bid;

public class BidForCreationDtoToBidProfile : Profile
{
    public BidForCreationDtoToBidProfile()
    {
        CreateMap<BidForCreationDto, Domain.Bids.Bid>()
            .ForMember(dest => dest.Auction, opts => opts.Ignore())
            .ForMember(dest => dest.AuctionId, opts => opts.Ignore())
            .ForMember(dest => dest.Id, opts => opts.Ignore());

        CreateMap<Domain.Bids.Bid, BidDto>();
    }
}
