using Domain.Events;
using Microsoft.Extensions.Logging;

namespace Application.TelegramUsers.EventHandlers;

public class TelegramUserUpdatedEventHandler : INotificationHandler<TelegramUserUpdatedEvent>
{
    private readonly ILogger<TelegramUserUpdatedEventHandler> _logger;

    public TelegramUserUpdatedEventHandler(ILogger<TelegramUserUpdatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TelegramUserUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("eblanists.dating domain event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}

