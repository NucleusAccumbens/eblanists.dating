using Domain.Events;
using Microsoft.Extensions.Logging;

namespace Application.TelegramUsers.EventHandlers;

public class TelegramUserDeletedEventHandler : INotificationHandler<TelegramUserDeletedEvent>
{
    private readonly ILogger<TelegramUserDeletedEventHandler> _logger;

    public TelegramUserDeletedEventHandler(ILogger<TelegramUserDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TelegramUserDeletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("eblanists.dating domain event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}

