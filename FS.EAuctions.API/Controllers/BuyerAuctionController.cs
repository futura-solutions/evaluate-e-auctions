using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FS.EAuctions.Application.BuyerAuctions.Create;
using FS.EAuctions.Application.BuyerAuctions.Get;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using Fs.EAuctions.Domain.Contracts;
using MediatR;

namespace FS.EAuctions.API.Controllers;

[Route("api/auctions")]
[ApiController]
public class BuyerAuctionController : ControllerBase
{
    private readonly ILogger<BuyerAuctionController> _logger;
    private readonly IRepository<Bid> _bidRepository;
    private readonly IBuyerAuctionRepository _buyerAuctionRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public BuyerAuctionController(
        ILogger<BuyerAuctionController> logger,
        IRepository<Bid> bidRepository,
        IBuyerAuctionRepository buyerAuctionRepository,
        IMapper mapper,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _bidRepository = bidRepository ?? throw new ArgumentNullException(nameof(bidRepository));
        _buyerAuctionRepository = buyerAuctionRepository ?? throw new ArgumentNullException(nameof(buyerAuctionRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<BuyerAuctionDto>> CreateRecipe(BuyerAuctionForCreationDto buyerAuctionForCreationDto)
    {
        try
        {
            var userGuid = Guid.NewGuid();
            var createBuyerAuctionCommand = new CreateBuyerAuctionCommand(buyerAuctionForCreationDto, userGuid);
            var buyerAuctionDto = await _mediator.Send(createBuyerAuctionCommand);

            return CreatedAtRoute("GetBuyerAuction",
                new
                {
                    buyerAuctionId = buyerAuctionDto.Id
                },
                buyerAuctionDto);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Exception while creating auction with id {recipeId}", ex);
            return StatusCode(500, "A problem happened while handling your request.");
        }
    }
}
