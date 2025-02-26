using AutoMapper;
using FS.EAuctions.Application.Bids.Create;
using FS.EAuctions.Application.BuyerAuctions.Create;
using FS.EAuctions.Application.SupplierAuctions.Create;
using FS.EAuctions.Domain.Auctions;

namespace FS.EAuctions.Application.Profiles.Auction;

public class BuyerAuctionForCreationDtoToSupplierAuctionForCreationDto : Profile
{
	public BuyerAuctionForCreationDtoToSupplierAuctionForCreationDto()
	{
		CreateMap<BuyerAuctionForCreationDto, SupplierAuctionForCreationDto>();
	}
}