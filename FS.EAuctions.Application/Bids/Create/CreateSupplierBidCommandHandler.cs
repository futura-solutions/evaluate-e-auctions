using AutoMapper;
using FluentValidation;
using FS.EAuctions.Application.Bids.Get;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using MediatR;

namespace FS.EAuctions.Application.Bids.Create;

public class CreateSupplierBidCommandHandler : IRequestHandler<CreateSupplierBidCommand, SupplierBidDto>
{
    IAuctionRepository<SupplierAuction, SupplierBid> _auctionRepository;
    IMapper _mapper;
    IValidator<CreateSupplierBidCommand> _validator;

    public CreateSupplierBidCommandHandler(IAuctionRepository<SupplierAuction, SupplierBid> auctionRepository, IMapper mapper, IValidator<CreateSupplierBidCommand> validator)
    {
        _auctionRepository = auctionRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<SupplierBidDto> Handle(CreateSupplierBidCommand request, CancellationToken cancellationToken)
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

        var newBid = _mapper.Map<Domain.Bids.SupplierBid>(request.SupplierBidForCreationDto);
        newBid.ReceivedAt = request.ReceivedAt;

        await _auctionRepository.AddBidToAuctionAsync(request.BuyerAuctionId, newBid);

        await _auctionRepository.SaveChangesAsync();

        return _mapper.Map<SupplierBidDto>(newBid);
    }
}
