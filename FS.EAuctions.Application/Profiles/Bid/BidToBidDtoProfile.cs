using AutoMapper;
using FS.EAuctions.Application.Bids.Get;

namespace FS.EAuctions.Application.Profiles.Bid;

public class BidToBidDtoProfile : Profile
{
    public BidToBidDtoProfile()
    {
        CreateMap<Domain.Bids.Bid, BidDto>();
    }
}
