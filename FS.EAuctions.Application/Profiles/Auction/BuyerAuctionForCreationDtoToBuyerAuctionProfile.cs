using AutoMapper;
using FS.EAuctions.Application.Bids.Create;
using FS.EAuctions.Application.BuyerAuctions.Create;
using FS.EAuctions.Domain.Auctions;

namespace FS.EAuctions.Application.Profiles.Auction;

public class BuyerAuctionForCreationDtoToBuyerAuctionProfile : Profile
{
	public BuyerAuctionForCreationDtoToBuyerAuctionProfile()
	{
		CreateMap<BuyerAuctionForCreationDto, BuyerAuction>()
			.ForMember(dest => dest.Id, opts => opts.Ignore())
			.ForMember(dest => dest.Bids, opts => opts.MapFrom(src => src.Bids));

		CreateMap<BidForCreationDto, Domain.Bids.Bid>();
	}
}