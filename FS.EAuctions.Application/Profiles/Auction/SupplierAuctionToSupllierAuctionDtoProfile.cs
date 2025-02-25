using AutoMapper;
using FS.EAuctions.Application.BuyerAuctions.Get;
using FS.EAuctions.Domain.Auctions;

namespace FS.EAuctions.Application.Profiles.Auction;

public class SupplierAuctionToSupplierAuctionDtoProfile : Profile
{
	public SupplierAuctionToSupplierAuctionDtoProfile()
	{
		CreateMap<SupplierAuction, SupplierAuctionDto>();
	}
}