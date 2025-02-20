using AutoMapper;
using FS.EAuctions.Application.Bids.Get;
using FS.EAuctions.Application.BuyerAuctions.Get;
using FS.EAuctions.Domain.Auctions;

namespace FS.EAuctions.Application.Profiles.Auction;

public class BuyerAuctionToBuyerAuctionDtoProfile : Profile
{
	public BuyerAuctionToBuyerAuctionDtoProfile()
	{
		CreateMap<BuyerAuction, BuyerAuctionDto>()
			.ForMember(dest => dest.Bids, opt => 
				opt.MapFrom(src => src.Bids));

		CreateMap<Domain.Bids.Bid, BidDto>();
	}
}