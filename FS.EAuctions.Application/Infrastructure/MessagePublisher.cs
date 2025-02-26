using System.Text;
using System.Text.Json;
using FS.EAuctions.API.Infrastructure;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace FS.EAuctions.Application.Infrastructure;

public class MessagePublisher : IMessagePublisher, IAsyncDisposable
{
    private readonly RabbitMQConfiguration _config;
    private IChannel? _channel;
    private IConnection _connection;

    public MessagePublisher(IOptions<RabbitMQConfiguration> config)
    {
        _config = config.Value;
    }

    public async Task InitializeAsync()
    {
        var factory = new ConnectionFactory() { HostName = _config.HostName };
        _connection = await factory.CreateConnectionAsync(); 
        _channel = await _connection.CreateChannelAsync(); 

        await _channel.QueueDeclareAsync(queue: _config.QueueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }
    
    public async Task PublishMessageAsync<T>(T messageObject)
    {
        if (_channel is null)
        {
            await InitializeAsync(); // Initialize only if not already initialized
        }
        
        var messageJson = JsonSerializer.Serialize(messageObject); // Serialize object to JSON
        var body = Encoding.UTF8.GetBytes(messageJson);
        
        var props = new BasicProperties
        {
            ContentType = "text/plain",
            DeliveryMode = DeliveryModes.Persistent
        };

        if (_channel != null)
            await _channel.BasicPublishAsync(exchange: "",
                routingKey: _config.QueueName,
                mandatory: true,
                basicProperties: props,
                body: body);
    }

    public async ValueTask DisposeAsync()
    {
        if (_channel != null) await _channel.DisposeAsync();
        await _connection.DisposeAsync();
    }
}