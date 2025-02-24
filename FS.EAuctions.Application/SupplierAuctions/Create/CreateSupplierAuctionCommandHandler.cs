using AutoMapper;
using FluentValidation;
using FS.EAuctions.Application.BuyerAuctions.Create;
using FS.EAuctions.Application.BuyerAuctions.Get;
using FS.EAuctions.Domain.Auctions;
using Fs.EAuctions.Domain.Contracts;
using MediatR;

namespace FS.EAuctions.Application.SupplierAuctions.Create;

public class CreateSupplierAuctionCommandHandler : IRequestHandler<CreateSupplierAuctionCommand, SupplierAuctionDto>
{
	private readonly IRepository<SupplierAuction> _supplierAuctionRepository;
	private readonly IMapper _mapper;
	private readonly IValidator<CreateSupplierAuctionCommand> _validator;

	public CreateSupplierAuctionCommandHandler(IRepository<SupplierAuction> supplierAuctionRepository, IMapper mapper, 
		IValidator<CreateSupplierAuctionCommand> validator)
	{
		_supplierAuctionRepository = supplierAuctionRepository;
		_mapper = mapper;
		_validator = validator;
	}

	public async Task<SupplierAuctionDto> Handle(CreateSupplierAuctionCommand request, CancellationToken cancellationToken)
	{
		var validationResult = await _validator.ValidateAsync(request, cancellationToken);

		if (!validationResult.IsValid)
		{
			throw new ValidationException(validationResult.Errors);
		}

		var newSupplierAuction = _mapper.Map<SupplierAuction>(request.SupplierAuctionForCreationDto);

		await _supplierAuctionRepository.AddAsync(newSupplierAuction);

		var supplierAuctionDto = _mapper.Map<SupplierAuctionDto>(newSupplierAuction);

		return supplierAuctionDto;
	}
}