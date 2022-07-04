using Domain.Events;
using Microsoft.Extensions.Logging;

namespace Application.TelegramUsers.EventHandlers;

public class TelegramUserCreatedEventHandler : INotificationHandler<TelegramUserCreatedEvent>
{
    private readonly ILogger<TelegramUserCreatedEventHandler> _logger;

    public TelegramUserCreatedEventHandler(ILogger<TelegramUserCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TelegramUserCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("eblanists.dating domain event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}

