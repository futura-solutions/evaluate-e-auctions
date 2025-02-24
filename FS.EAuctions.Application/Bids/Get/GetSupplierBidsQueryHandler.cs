using AutoMapper;
using FS.EAuctions.Application.Exceptions;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using MediatR;

namespace FS.EAuctions.Application.Bids.Get;

public class GetSupplierBidsQueryHandler : IRequestHandler<GetSupplierBidsQuery, IEnumerable<SupplierBidDto>>
{
    IAuctionRepository<BuyerAuction,BuyerBid> _buyerAuctionRepository;
    IMapper _mapper;

    public GetSupplierBidsQueryHandler(IAuctionRepository<BuyerAuction, BuyerBid> buyerAuctionRepository, IMapper mapper)
    {
        _buyerAuctionRepository = buyerAuctionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SupplierBidDto>> Handle(GetSupplierBidsQuery request, CancellationToken cancellationToken)
    {
        if (!await _buyerAuctionRepository.BidExistsAsync(request.AuctionId))
        {
            throw new BidNotFoundException(request.AuctionId);
        }

        var bids = await _buyerAuctionRepository.GetBidsForAuctionAsync(request.AuctionId);

        var bidDtos = _mapper.Map<IEnumerable<SupplierBidDto>>(bids);
        
        return bidDtos;
    }
}
