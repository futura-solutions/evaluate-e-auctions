using AutoMapper;
using FS.EAuctions.Application.BuyerAuctions.Get;
using FS.EAuctions.Application.Exceptions;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using MediatR;

namespace FS.EAuctions.Application.SupplierAuctions.Get;

public class GetSupplierAuctionByIdQueryHandler : IRequestHandler<GetSupplierAuctionByIdQuery, SupplierAuctionDto>
{
	private readonly IAuctionRepository<SupplierAuction, SupplierBid> _auctionRepository;
	private readonly IMapper _mapper;

	public GetSupplierAuctionByIdQueryHandler(IAuctionRepository<SupplierAuction, SupplierBid> auctionRepository, IMapper mapper)
	{
		_auctionRepository = auctionRepository;
		_mapper = mapper;
	}

	public async Task<SupplierAuctionDto> Handle(GetSupplierAuctionByIdQuery request, CancellationToken cancellationToken)
	{
		if(!await _auctionRepository.AuctionExistsAsync(request.SupplierAuctionId))
		{
			throw new BuyerAuctionNotFoundException(request.SupplierAuctionId);
		}

		var supplierAuctionEntity = await _auctionRepository.GetAuctionAsync(request.SupplierAuctionId, true);

		var supplierAuctionDto = _mapper.Map<SupplierAuctionDto>(supplierAuctionEntity);

		return supplierAuctionDto;
	}
}