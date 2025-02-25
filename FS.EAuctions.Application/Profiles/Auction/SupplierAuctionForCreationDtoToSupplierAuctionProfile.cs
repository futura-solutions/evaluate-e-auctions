using AutoMapper;
using FS.EAuctions.Application.Bids.Create;
using FS.EAuctions.Application.BuyerAuctions.Create;
using FS.EAuctions.Application.SupplierAuctions.Create;
using FS.EAuctions.Domain.Auctions;

namespace FS.EAuctions.Application.Profiles.Auction;

public class SupplierAuctionForCreationDtoToSupplierAuctionProfile : Profile
{
	public SupplierAuctionForCreationDtoToSupplierAuctionProfile()
	{
		CreateMap<SupplierAuctionForCreationDto, SupplierAuction>()
			.ForMember(dest => dest.Id, opts => opts.Ignore());
			
		CreateMap<SupplierBidForCreationDto, Domain.Bids.SupplierBid>();
	}
}