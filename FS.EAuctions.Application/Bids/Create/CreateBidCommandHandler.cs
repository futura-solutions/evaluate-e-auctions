using AutoMapper;
using FluentValidation;
using FS.EAuctions.Application.Bids.Get;
using FS.EAuctions.Domain.Auctions;
using MediatR;

namespace FS.EAuctions.Application.Bids.Create;

public class CreateBidCommandHandler : IRequestHandler<CreateBidCommand, BidDto>
{
    IBuyerAuctionRepository _buyerAuctionRepository;
    IMapper _mapper;
    IValidator<CreateBidCommand> _validator;

    public CreateBidCommandHandler(IBuyerAuctionRepository buyerAuctionRepository, IMapper mapper, IValidator<CreateBidCommand> validator)
    {
        _buyerAuctionRepository = buyerAuctionRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<BidDto> Handle(CreateBidCommand request, CancellationToken cancellationToken)
    {
        
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // if (!await _auctionRepository.BidExistsAsync(request.RecipeId))
        // {
        //     throw new RecipeNotFoundException(request.RecipeId);
        // }

        var newBid = _mapper.Map<Domain.Bids.Bid>(request.BidForCreationDto);
        newBid.ReceivedAt = request.ReceivedAt;

        await _buyerAuctionRepository.AddBidToAuctionAsync(request.BuyerAuctionId, newBid);

        await _buyerAuctionRepository.SaveChangesAsync();

        return _mapper.Map<BidDto>(newBid);
    }
}
