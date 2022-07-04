namespace Domain.Events;

public class TelegramUserCreatedEvent : BaseEvent
{
    public TelegramUserCreatedEvent(TelegramUser telegramUser)
    {
        TelegramUser = telegramUser;
    }

    public TelegramUser TelegramUser { get; }
}

