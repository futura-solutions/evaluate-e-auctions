using FluentValidation;

namespace FS.EAuctions.Application.Bids.Create;

public class CreateBidCommandValidator : AbstractValidator<CreateBidCommand>
{
    public CreateBidCommandValidator()
    {
        RuleFor(x => x.BidForCreationDto.Name).NotEmpty()
            .WithMessage("Name of bid must not be empty")
            .MaximumLength(50)
            .WithMessage("Name of bid must not exceed 50 characters");

        RuleFor(x => x.BidForCreationDto.Quantity).NotEmpty()
          .WithMessage("The quantity must not be empty");

        RuleFor(x => x.BidForCreationDto.Unit).NotEmpty()
            .WithMessage("The unit must not be empty")
            .MaximumLength(10)
            .WithMessage("Name of unit must not exceed 10 characters");
    }
}
