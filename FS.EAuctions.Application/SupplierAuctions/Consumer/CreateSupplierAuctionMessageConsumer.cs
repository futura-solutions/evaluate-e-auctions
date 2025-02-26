using System.Text;
using System.Text.Json;
using FS.EAuctions.Application.BuyerAuctions.Create;
using FS.EAuctions.Application.SupplierAuctions.Create;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FS.EAuctions.Application.SupplierAuctions.Consumer;

public class CreateSupplierAuctionMessageConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _config;
    private readonly ILogger<CreateSupplierAuctionMessageConsumer> _logger;
    private IConnection? _connection;
    private IChannel? _channel;
    
    public CreateSupplierAuctionMessageConsumer(IServiceProvider serviceProvider, 
        IConfiguration config,
        ILogger<CreateSupplierAuctionMessageConsumer> logger)
    {
        _serviceProvider = serviceProvider;
        _config = config;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_channel == null)
            await InitializeRabbitMqAsync();

        _logger.LogInformation("Waiting for messages...");

        if (_channel != null)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (sender, eventArgs) => { await ProcessMessage(eventArgs); };

            await _channel.BasicConsumeAsync(queue: _config["RabbitMQConfiguration:QueueName"],
                autoAck: false,
                consumer: consumer);
        }
    }

    private async Task InitializeRabbitMqAsync()
    {
        var factory = new ConnectionFactory() { HostName = _config["RabbitMQConfiguration:HostName"] };
        _connection = await factory.CreateConnectionAsync();
        _channel = await _connection.CreateChannelAsync();

        await _channel.QueueDeclareAsync(
            queue: _config["RabbitMQConfiguration:QueueName"],
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        _logger.LogInformation("Connected to RabbitMQ");
    }

    private async Task ProcessMessage(BasicDeliverEventArgs eventArgs)
    {
        var messageJson = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
        _logger.LogInformation($"Received message: {messageJson}");

        try
        {
            var buyerAuctionForCreationDto = JsonSerializer.Deserialize<BuyerAuctionForCreationDto>(messageJson);
            if (buyerAuctionForCreationDto == null) throw new Exception("Failed to deserialize message.");

            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var command = new CreateSupplierAuctionCommand(
                new SupplierAuctionForCreationDto(
                    Name: "TestAuction",
                    StartAuctionDateTime: DateTimeOffset.UtcNow,
                    EndAuctionDateTime: DateTimeOffset.UtcNow.AddMinutes(10),
                    Description: buyerAuctionForCreationDto.Description,
                    CreatedBy: Guid.NewGuid()
                ),
                Guid.NewGuid()
            );

            await mediator.Send(command);

            // Acknowledge the message after processing
            await _channel!.BasicAckAsync(eventArgs.DeliveryTag, false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing message. Sending to dead-letter queue or logging.");
            await _channel!.BasicNackAsync(eventArgs.DeliveryTag, false, false); // Reject the message
        }
    }
    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await _channel?.CloseAsync()!;
        await _connection?.CloseAsync()!;
        await base.StopAsync(cancellationToken);
    }
}