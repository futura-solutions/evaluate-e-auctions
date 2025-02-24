﻿using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FS.EAuctions.Application.BuyerAuctions.Create;
using FS.EAuctions.Application.BuyerAuctions.Get;
using FS.EAuctions.Application.Exceptions;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using Fs.EAuctions.Domain.Contracts;
using MediatR;

namespace FS.EAuctions.API.Controllers;

[Route("api/buyerauctions")]
[ApiController]
public class BuyerAuctionController : ControllerBase
{
    private readonly ILogger<BuyerAuctionController> _logger;
    private readonly IRepository<SupplierBid> _bidRepository;
    private readonly IAuctionRepository<BuyerAuction, BuyerBid> _auctionRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public BuyerAuctionController(
        ILogger<BuyerAuctionController> logger,
        IRepository<SupplierBid> bidRepository,
        IAuctionRepository<BuyerAuction, BuyerBid> auctionRepository,
        IMapper mapper,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _bidRepository = bidRepository ?? throw new ArgumentNullException(nameof(bidRepository));
        _auctionRepository = auctionRepository ?? throw new ArgumentNullException(nameof(auctionRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _mediator = mediator;
    }

    [HttpGet("{buyerAuctionId}", Name = "GetBuyerAuction")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BuyerAuctionDto>> GetBuyerAuction(Guid buyerAuctionId)
    {
        try
        {
            var getBuyerAuctionQuery = new GetBuyerAuctionByIdQuery(buyerAuctionId);
            var buyerAuctionDto = await _mediator.Send(getBuyerAuctionQuery);

            return Ok(buyerAuctionDto);
        }
        catch (BuyerAuctionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"Exception while getting recipe with id {buyerAuctionId}", ex);
            return StatusCode(500, "A problem happened while handling your request.");
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<BuyerAuctionDto>> CreateAuction(BuyerAuctionForCreationDto buyerAuctionForCreationDto)
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
