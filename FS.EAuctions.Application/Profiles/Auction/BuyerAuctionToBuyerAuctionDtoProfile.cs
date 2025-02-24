using AutoMapper;
using FS.EAuctions.Application.BuyerAuctions.Get;
using FS.EAuctions.Domain.Auctions;

namespace FS.EAuctions.Application.Profiles.Auction;

public class BuyerAuctionToBuyerAuctionDtoProfile : Profile
{
	public BuyerAuctionToBuyerAuctionDtoProfile()
	{
		CreateMap<BuyerAuction, BuyerAuctionDto>();
	}
}