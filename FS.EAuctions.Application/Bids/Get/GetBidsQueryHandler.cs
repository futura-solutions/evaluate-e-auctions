using AutoMapper;
using FS.EAuctions.Application.Exceptions;
using FS.EAuctions.Domain.Auctions;
using MediatR;

namespace FS.EAuctions.Application.Bids.Get;

public class GetBidsQueryHandler : IRequestHandler<GetBidsQuery, IEnumerable<BidDto>>
{
    IBuyerAuctionRepository _buyerAuctionRepository;
    IMapper _mapper;

    public GetBidsQueryHandler(IBuyerAuctionRepository buyerAuctionRepository, IMapper mapper)
    {
        _buyerAuctionRepository = buyerAuctionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BidDto>> Handle(GetBidsQuery request, CancellationToken cancellationToken)
    {
        if (!await _buyerAuctionRepository.BidExistsAsync(request.AuctionId))
        {
            throw new BidNotFoundException(request.AuctionId);
        }

        var bids = await _buyerAuctionRepository.GetBidsForAuctionAsync(request.AuctionId);

        var bidDtos = _mapper.Map<IEnumerable<BidDto>>(bids);
        
        return bidDtos;
    }
}
