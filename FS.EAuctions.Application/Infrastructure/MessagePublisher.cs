using System.Text;
using FS.EAuctions.API.Infrastructure;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace FS.EAuctions.Application.Infrastructure;

public class MessagePublisher : IMessagePublisher
{
    private readonly RabbitMQConfiguration _config;

    public MessagePublisher(IOptions<RabbitMQConfiguration> config)
    {
        _config = config.Value;
    }

    public async Task PublishMessageAsync(string message)
    {
        var factory = new ConnectionFactory() { HostName = _config.HostName };

        await using var connection = await factory.CreateConnectionAsync(); // ✅ Use CreateConnectionAsync() in v7.1.0
        await using var channel = await connection.CreateChannelAsync(); // ✅ Use CreateChannelAsync() instead of CreateModel()

        await channel.QueueDeclareAsync(queue: _config.QueueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var body = Encoding.UTF8.GetBytes(message);
        
        var props = new BasicProperties();
        props.ContentType = "text/plain";
        props.DeliveryMode = DeliveryModes.Persistent;

        await channel.BasicPublishAsync(exchange: "",
            routingKey: _config.QueueName,
            mandatory: true,
            basicProperties: props,
            body: body);
    }
}