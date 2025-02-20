// using AutoMapper;
// using FluentValidation;
// using FS.EAuctions.Application.Exceptions;
// using FS.EAuctions.Domain.Auctions;
// using MediatR;
//
// namespace FS.EAuctions.Application.Bid.Update;
//
// public class UpdateIngredientCommandHandler : IRequestHandler<UpdateBidCommand>
// {
//     IBuyerAuctionRepository _buyerAuctionRepository;
//     IMapper _mapper;
//     IValidator<UpdateBidCommand> _validator;
//
//     public UpdateIngredientCommandHandler(IBuyerAuctionRepository buyerAuctionRepository, IMapper mapper, IValidator<UpdateBidCommand> validator)
//     {
//         _buyerAuctionRepository = buyerAuctionRepository;
//         _mapper = mapper;
//         this._validator = validator;
//     }
//
//     public async Task Handle(UpdateBidCommand request, CancellationToken cancellationToken)
//     {
//         var validationResult = await _validator.ValidateAsync(request, cancellationToken);
//
//         if (!validationResult.IsValid)
//         {
//             throw new ValidationException(validationResult.Errors);
//         }
//
//
//         // if (!await _auctionRepository.BidExistsAsync(request.RecipeId))
//         // {
//         //     throw new RecipeNotFoundException(request.RecipeId);
//         // }
//
//         var bidEntity = await _buyerAuctionRepository.GetBidForAuctionAsync(request.BidId, 
//             request.BidId);
//         
//         if (bidEntity == null)
//         {
//             throw new BidNotFoundException(request.BidId);
//         }
//
//         _mapper.Map(request.BidForUpdateDto, bidEntity);
//
//         await _buyerAuctionRepository.SaveChangesAsync();
//     }
// }
