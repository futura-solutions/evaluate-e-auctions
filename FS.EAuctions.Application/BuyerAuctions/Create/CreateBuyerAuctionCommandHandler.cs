using AutoMapper;
using FluentValidation;
using FS.EAuctions.Application.BuyerAuctions.Get;
using FS.EAuctions.Domain.Auctions;
using Fs.EAuctions.Domain.Contracts;
using MediatR;

namespace FS.EAuctions.Application.BuyerAuctions.Create;

public class CreateBuyerAuctionCommandHandler : IRequestHandler<CreateBuyerAuctionCommand, BuyerAuctionDto>
{
	private readonly IRepository<BuyerAuction> _buyerAuctionRepository;
	private readonly IMapper _mapper;
	private readonly IValidator<CreateBuyerAuctionCommand> _validator;

	public CreateBuyerAuctionCommandHandler(IRepository<BuyerAuction> buyerAuctionRepository, IMapper mapper, IValidator<CreateBuyerAuctionCommand> validator)
	{
		_buyerAuctionRepository = buyerAuctionRepository;
		_mapper = mapper;
		_validator = validator;
	}

	public async Task<BuyerAuctionDto> Handle(CreateBuyerAuctionCommand request, CancellationToken cancellationToken)
	{
		var validationResult = await _validator.ValidateAsync(request, cancellationToken);

		if (!validationResult.IsValid)
		{
			throw new ValidationException(validationResult.Errors);
		}

		var newBuyerAuction = _mapper.Map<BuyerAuction>(request.BuyerAuctionForCreationDto);

		await _buyerAuctionRepository.AddAsync(newBuyerAuction);

		var buyerAuctionDto = _mapper.Map<BuyerAuctionDto>(newBuyerAuction);

		return buyerAuctionDto;
	}
}