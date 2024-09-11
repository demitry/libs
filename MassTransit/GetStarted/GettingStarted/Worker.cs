using GettingStarted;
using MassTransit;

public class Worker : BackgroundService
{
    readonly IBus _bus;

    public Worker(IBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = new Message { Text = $"The time is {DateTimeOffset.Now}" };
            await _bus.Publish(message);
            Console.WriteLine("Message published: " + message.Text);
            await Task.Delay(1000, stoppingToken);
        }
    }
}