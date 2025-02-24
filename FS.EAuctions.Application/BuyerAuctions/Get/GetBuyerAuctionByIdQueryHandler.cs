using AutoMapper;
using FS.EAuctions.Application.Exceptions;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using MediatR;

namespace FS.EAuctions.Application.BuyerAuctions.Get;

public class GetBuyerAuctionByIdQueryHandler : IRequestHandler<GetBuyerAuctionByIdQuery, BuyerAuctionDto>
{
	private readonly IAuctionRepository<BuyerAuction, BuyerBid> _auctionRepository;
	private readonly IMapper _mapper;

	public GetBuyerAuctionByIdQueryHandler(IAuctionRepository<BuyerAuction, BuyerBid> auctionRepository, IMapper mapper)
	{
		_auctionRepository = auctionRepository;
		_mapper = mapper;
	}

	public async Task<BuyerAuctionDto> Handle(GetBuyerAuctionByIdQuery request, CancellationToken cancellationToken)
	{
		if(!await _auctionRepository.AuctionExistsAsync(request.BuyerAuctionId))
		{
			throw new BuyerAuctionNotFoundException(request.BuyerAuctionId);
		}

		var buyerAuctionEntity = await _auctionRepository.GetAuctionAsync(request.BuyerAuctionId, true);

		var buyerAuctionDto = _mapper.Map<BuyerAuctionDto>(buyerAuctionEntity);

		return buyerAuctionDto;
	}
}