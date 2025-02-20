using Asp.Versioning;
using AutoMapper;
using FS.EAuctions.Application.Bids.Create;
using FS.EAuctions.Application.Bids.Get;
using FS.EAuctions.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FS.EAuctions.API.Controllers;

/// <summary>
/// Controller for managing bids.
/// </summary>
[Route("api/buyerauctions/{buyerAuctionId}/bids")]
[ApiController]
[ApiVersion(2)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class BidController : ControllerBase
{
	private readonly ILogger<BidController> _logger;
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	public BidController(
		ILogger<BidController> logger,
		IMapper mapper,
		IMediator mediator)
	{
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		_mediator = mediator;
	}

	/// <summary>
	/// Gets a list of bids for an auction.
	/// </summary>
	/// <param name="buyerAuctionId">The recipe ID.</param>
	/// <returns>A list of bids.</returns>
	/// <response code="200">Returns the list of bids.</response>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<IEnumerable<BidDto>>> GetBids(Guid buyerAuctionId)
	{
		try
		{
			var getBidsQuery = new GetBidsQuery(buyerAuctionId);
			var bidDtos = await _mediator.Send(getBidsQuery);

			return Ok(bidDtos);
		}
		catch (BuyerAuctionNotFoundException ex)
		{
			return NotFound(ex.Message);
		}
		catch (Exception ex)
		{
			_logger.LogCritical($"Exception while getting bids for buyer auction with id {buyerAuctionId}", ex);
			return StatusCode(500, "A problem happened while handling your request.");
		}
	}

	/// <summary>
	/// Gets a bid for a buyer auction.
	/// </summary>
	/// <param name="buyerAuctionId">The buyer auction ID.</param>
	/// <param name="bidId">The bid ID.</param>
	/// <returns>The bid.</returns>
	/// <response code="200">Returns the bid.</response>
	[HttpGet("{bidId}", Name = "GetBid")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<BidDto>> GetBid(Guid buyerAuctionId, Guid bidId)
	{
		try
		{
			var getBidQuery = new GetBidQuery(buyerAuctionId, bidId);
			var bidDto = await _mediator.Send(getBidQuery);
	
			return Ok(bidDto);
		}
		catch (BuyerAuctionNotFoundException ex)
		{
			return NotFound(ex.Message);
		}
		catch (BidNotFoundException ex)
		{
			return NotFound(ex.Message);
		}
		catch (Exception ex)
		{
			_logger.LogCritical($"Exception while getting bid with id {bidId} for buyer auction with id {buyerAuctionId}", ex);
			return StatusCode(500, "A problem happened while handling your request.");
		}
	}

	/// <summary>
	/// Creates a new bid for a buyer auction.
	/// </summary>
	/// <param name="buyerAuctionId">The recipe ID.</param>
	/// <param name="bidForCreationDto">The bid for creation DTO.</param>
	/// <returns>The created bid.</returns>
	/// <response code="201">Returns the created bid.</response>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<ActionResult<BidDto>> CreateBid(Guid buyerAuctionId, BidForCreationDto bidForCreationDto)
	{
		try
		{
			var receivedAt = DateTime.UtcNow;
			var createBidCommand = new CreateBidCommand(buyerAuctionId, bidForCreationDto, receivedAt);
			var bidDto = await _mediator.Send(createBidCommand);
			//var bidDto = new BidDto(Guid.NewGuid(), "Empty",3, "m");
			
			return CreatedAtRoute("GetBid",
				new
				{
					buyerAuctionId,
					bidId = bidDto.Id
				},
				bidDto);
		}
		catch (BidNotFoundException ex)
		{
			return NotFound(ex.Message);
		}
		catch (Exception ex)
		{
			_logger.LogCritical($"Exception while creating bid for buyer auction with id {buyerAuctionId}", ex);
			return StatusCode(500, "A problem happened while handling your request.");
		}
	}
}