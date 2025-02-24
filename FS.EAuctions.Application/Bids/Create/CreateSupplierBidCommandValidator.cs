using FluentValidation;

namespace FS.EAuctions.Application.Bids.Create;

public class CreateSupplierBidCommandValidator : AbstractValidator<CreateSupplierBidCommand>
{
    public CreateSupplierBidCommandValidator()
    {
        RuleFor(x => x.SupplierBidForCreationDto.Name).NotEmpty()
            .WithMessage("Name of bid must not be empty")
            .MaximumLength(50)
            .WithMessage("Name of bid must not exceed 50 characters");

        RuleFor(x => x.SupplierBidForCreationDto.Quantity).NotEmpty()
          .WithMessage("The quantity must not be empty");

        RuleFor(x => x.SupplierBidForCreationDto.Unit).NotEmpty()
            .WithMessage("The unit must not be empty")
            .MaximumLength(10)
            .WithMessage("Name of unit must not exceed 10 characters");
    }
}
