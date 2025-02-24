using Microsoft.AspNetCore.SignalR;

namespace FS.EAuctions.API.BackgroundServices;

public class TimerBackgroundService : BackgroundService
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public TimerBackgroundService(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            string currentTime = DateTime.UtcNow.ToString("HH:mm:ss");

            try
            {
                await _hubContext.Clients.All.SendAsync("ReceiveTime", currentTime, stoppingToken);
                Console.WriteLine($"Sent time update: {currentTime}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending time update: {ex.Message}");
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}