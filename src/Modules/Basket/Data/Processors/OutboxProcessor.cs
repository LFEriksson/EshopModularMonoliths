using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Basket.Data.Processors;

public class OutboxProcessor(
    IServiceProvider serviceProvider,
    IBus bus,
    ILogger<OutboxProcessor> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<BasketDbContext>();
                var outboxMessages = await dbContext.OutboxMessages
                    .Where(x => x.ProcessedOnUTC == null)
                    .OrderBy(x => x.OccuredOnUTC)
                    .Take(100)
                    .ToListAsync(stoppingToken);

                foreach (var message in outboxMessages)
                {
                    var eventType = Type.GetType(message.Type);
                    if (eventType == null)
                    {
                        logger.LogWarning("Event type {Type} not found", message.Type);
                        continue;
                    }

                    var eventMessage = JsonSerializer.Deserialize(message.Content, eventType);
                    if (eventMessage == null)
                    {
                        logger.LogWarning("Event message {Type} not found", message.Type);
                        continue;
                    }

                    await bus.Publish(eventMessage, stoppingToken);

                    message.ProcessedOnUTC = DateTime.UtcNow;

                    logger.LogInformation("Event {Type} published with id: {ID}", message.Type, message.Id);
                }

                await dbContext.SaveChangesAsync(stoppingToken);
            }

            catch (Exception)
            {
                logger.LogError("Error processing outbox messages");
            }

            await Task.Delay(10000, stoppingToken);
        }
    }
}
