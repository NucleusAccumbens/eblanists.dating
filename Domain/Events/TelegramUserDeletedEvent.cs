namespace Domain.Events;

public class TelegramUserDeletedEvent : BaseEvent
{
    public TelegramUserDeletedEvent(TelegramUser telegramUser)
    {
        TelegramUser = telegramUser;
    }

    public TelegramUser TelegramUser { get; }
}

