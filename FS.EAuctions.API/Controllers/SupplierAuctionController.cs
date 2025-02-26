using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FS.EAuctions.Application.BuyerAuctions.Create;
using FS.EAuctions.Application.BuyerAuctions.Get;
using FS.EAuctions.Application.Exceptions;
using FS.EAuctions.Application.SupplierAuctions.Create;
using FS.EAuctions.Application.SupplierAuctions.Get;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using Fs.EAuctions.Domain.Contracts;
using MediatR;

namespace FS.EAuctions.API.Controllers;

[Route("api/supplierauctions")]
[ApiController]
public class SupplierAuctionController : ControllerBase
{
    private readonly ILogger<SupplierAuctionController> _logger;
    private readonly IRepository<SupplierBid> _bidRepository;
    private readonly IAuctionRepository<SupplierAuction, SupplierBid> _auctionRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public SupplierAuctionController(
        ILogger<SupplierAuctionController> logger,
        IRepository<SupplierBid> bidRepository,
        IAuctionRepository<SupplierAuction, SupplierBid> auctionRepository,
        IMapper mapper,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _bidRepository = bidRepository ?? throw new ArgumentNullException(nameof(bidRepository));
        _auctionRepository = auctionRepository ?? throw new ArgumentNullException(nameof(auctionRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _mediator = mediator;
    }

    [HttpGet("{supplierAuctionId}", Name = "GetSupplierAuction")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BuyerAuctionDto>> GetSupplierAuction(Guid supplierAuctionId)
    {
        try
        {
            var getSupplierAuctionQuery = new GetSupplierAuctionByIdQuery(supplierAuctionId);
            var supplierAuctionDto = await _mediator.Send(getSupplierAuctionQuery);

            return Ok(supplierAuctionDto);
        }
        catch (SupplierAuctionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"Exception while getting recipe with id {supplierAuctionId}", ex);
            return StatusCode(500, "A problem happened while handling your request.");
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<SupplierAuctionDto>> CreateAuction(SupplierAuctionForCreationDto supplierAuctionForCreationDto)
    {
        try
        {
            var userGuid = Guid.NewGuid();
            var createSupplierAuctionCommand = new CreateSupplierAuctionCommand(supplierAuctionForCreationDto, userGuid);
            var buyerAuctionDto = await _mediator.Send(createSupplierAuctionCommand);

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
