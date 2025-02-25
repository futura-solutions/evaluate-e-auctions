namespace FS.EAuctions.Application.Infrastructure;

public interface IMessagePublisher
{
    public Task PublishMessageAsync(string message);
}