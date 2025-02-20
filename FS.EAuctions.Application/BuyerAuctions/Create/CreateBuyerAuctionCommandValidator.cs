using FluentValidation;

namespace FS.EAuctions.Application.BuyerAuctions.Create;

public class CreateBuyerAuctionCommandValidator : AbstractValidator<CreateBuyerAuctionCommand>
{
	public CreateBuyerAuctionCommandValidator()
	{
		RuleFor(x => x.BuyerAuctionForCreationDto.Name).NotEmpty()
			.WithMessage("Name of recipe must not be empty")
			.MaximumLength(50)
			.WithMessage("Name of recipe must not exceed 50 characters");

		RuleFor(x => x.BuyerAuctionForCreationDto.Description).NotEmpty()
			.WithMessage("Description of recipe must not be empty")
			.MaximumLength(500)
			.WithMessage("Description of recipe must not exceed 500 characters");
	}
}