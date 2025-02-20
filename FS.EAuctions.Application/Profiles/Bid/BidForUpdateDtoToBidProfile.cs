using AutoMapper;
using FS.EAuctions.Application.Bids.Update;

namespace FS.EAuctions.Application.Profiles.Bid;

public class BidForUpdateDtoToBidProfile : Profile
{
    public BidForUpdateDtoToBidProfile()
    {
        CreateMap<BidForUpdateDto, Domain.Bids.Bid>()
            .ForMember(dest => dest.Auction, opts => opts.Ignore())
            .ForMember(dest => dest.AuctionId, opts => opts.Ignore())
            .ForMember(dest => dest.Id, opts => opts.Ignore());
    }
}
