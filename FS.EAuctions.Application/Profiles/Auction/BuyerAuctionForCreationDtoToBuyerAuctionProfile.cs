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
			.ForMember(dest => dest.Id, opts => opts.Ignore());
			
		CreateMap<SupplierBidForCreationDto, Domain.Bids.SupplierBid>();
	}
}