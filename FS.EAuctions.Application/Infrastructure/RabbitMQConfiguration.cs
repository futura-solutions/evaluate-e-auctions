namespace FS.EAuctions.API.Infrastructure;

public class RabbitMQConfiguration
{
    public string HostName { get; set; } = String.Empty;
    public string QueueName { get; set; } = String.Empty;
}