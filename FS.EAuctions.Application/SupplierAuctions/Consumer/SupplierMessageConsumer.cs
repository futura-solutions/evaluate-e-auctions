using System.Text;
using FS.EAuctions.Application.BuyerAuctions.Create;
using FS.EAuctions.Application.SupplierAuctions.Create;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FS.EAuctions.Application.SupplierAuctions.Consumer;

public class SupplierMessageConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _config;
    private IConnection? _connection;
    private IChannel? _channel;
    
    public SupplierMessageConsumer(IServiceProvider serviceProvider, IConfiguration config)
    {
        _serviceProvider = serviceProvider;
        _config = config;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = _config["RabbitMQConfiguration:HostName"] };
        _connection = await factory.CreateConnectionAsync();
        _channel = await _connection.CreateChannelAsync();

        await _channel.QueueDeclareAsync(queue: _config["RabbitMQConfiguration:QueueName"],
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.ReceivedAsync += async (sender, eventArgs) =>
        {
            var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());

            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var supplierAuctionForCreationDto = new SupplierAuctionForCreationDto(
                Name: "TestAuction",
                StartAuctionDateTime: DateTime.Now,
                EndAuctionDateTime: DateTime.Now,
                Description: message,
                CreatedBy: Guid.NewGuid()
                );
            
            await mediator.Send(new CreateSupplierAuctionCommand(supplierAuctionForCreationDto, Guid.NewGuid()));

            await _channel!.BasicAckAsync(eventArgs.DeliveryTag, false);
        };

        await _channel.BasicConsumeAsync(queue: _config["RabbitMQConfiguration:QueueName"],
            autoAck: false,
            consumer: consumer);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await _channel?.CloseAsync()!;
        await _connection?.CloseAsync()!;
        await base.StopAsync(cancellationToken);
    }
}