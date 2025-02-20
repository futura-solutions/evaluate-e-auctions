// using FluentValidation;
//
// namespace FS.EAuctions.Application.Bid.Update;
//
// public class UpdateIngredientCommandValidator : AbstractValidator<UpdateBidCommand>
// {
//     public UpdateIngredientCommandValidator()
//     {
//         RuleFor(x => x.BidForUpdateDto.Name).NotEmpty()
//             .WithMessage("Name of ingredient must not be empty")
//             .MaximumLength(50)
//             .WithMessage("Name of ingredient must not exceed 50 characters");
//
//         RuleFor(x => x.BidForUpdateDto.Quantity).NotEmpty()
//           .WithMessage("The quantity must not be empty");
//
//         RuleFor(x => x.BidForUpdateDto.Unit).NotEmpty()
//             .WithMessage("The unit must not be empty")
//             .MaximumLength(10)
//             .WithMessage("Name of unit must not exceed 10 characters");
//     }
// }
