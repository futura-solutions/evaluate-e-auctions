using AutoMapper;
using FluentValidation;
using FS.EAuctions.Application.Bids.Get;
using FS.EAuctions.Domain.Auctions;
using FS.EAuctions.Domain.Bids;
using MediatR;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace FS.EAuctions.Application.Bids.Create;

public class CreateSupplierBidCommandHandler : IRequestHandler<CreateSupplierBidCommand, SupplierBidDto>
{
    IAuctionRepository<SupplierAuction, SupplierBid> _auctionRepository;
    IMapper _mapper;
    IValidator<CreateSupplierBidCommand> _validator;
    
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _config;
    private IConnection? _connection;
    private IChannel? _channel;

    public CreateSupplierBidCommandHandler(IAuctionRepository<SupplierAuction, 
        SupplierBid> auctionRepository, 
        IMapper mapper, 
        IValidator<CreateSupplierBidCommand> validator,
        IServiceProvider serviceProvider, IConfiguration config)
    {
        _auctionRepository = auctionRepository;
        _mapper = mapper;
        _validator = validator;
        _serviceProvider = serviceProvider;
        _config = config;
    }

    public async Task<SupplierBidDto> Handle(CreateSupplierBidCommand request, CancellationToken cancellationToken)
    {
        
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var factory = new ConnectionFactory() { HostName = _config["RabbitMQConfiguration:HostName"] };
        _connection = await factory.CreateConnectionAsync();
        _channel = await _connection.CreateChannelAsync();

        var newBid = _mapper.Map<Domain.Bids.SupplierBid>(request.SupplierBidForCreationDto);
        newBid.ReceivedAt = request.ReceivedAt;

        // do not save directly but push the message to the queue
        
        //await _auctionRepository.AddBidToAuctionAsync(request.BuyerAuctionId, newBid);

        await _auctionRepository.SaveChangesAsync();

        return _mapper.Map<SupplierBidDto>(newBid);
    }
}
