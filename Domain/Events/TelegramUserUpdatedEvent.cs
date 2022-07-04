namespace Domain.Events;

public class TelegramUserUpdatedEvent : BaseEvent
{
    public TelegramUserUpdatedEvent(TelegramUser telegramUser)
    {
        TelegramUser = telegramUser;
    }

    public TelegramUser TelegramUser { get; }
}

