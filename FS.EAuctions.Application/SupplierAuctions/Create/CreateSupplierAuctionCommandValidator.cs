using FluentValidation;
using FS.EAuctions.Application.BuyerAuctions.Create;

namespace FS.EAuctions.Application.SupplierAuctions.Create;

public class CreateSupplierAuctionCommandValidator : AbstractValidator<CreateSupplierAuctionCommand>
{
	public CreateSupplierAuctionCommandValidator()
	{
		RuleFor(x => x.SupplierAuctionForCreationDto.Name).NotEmpty()
			.WithMessage("Name of recipe must not be empty")
			.MaximumLength(50)
			.WithMessage("Name of recipe must not exceed 50 characters");

		RuleFor(x => x.SupplierAuctionForCreationDto.Description).NotEmpty()
			.WithMessage("Description of recipe must not be empty")
			.MaximumLength(500)
			.WithMessage("Description of recipe must not exceed 500 characters");
	}
}