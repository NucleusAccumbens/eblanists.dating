using MediatR;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Common;

public abstract class TelegramCommand
{
    public abstract string Name { get; }

    public abstract Task Execute(Update update, ITelegramBotClient client, CancellationToken cancellationToken);

    public virtual bool? Contains(Message message)
    {
        if (message.Type != MessageType.Text)
            return false;

        return message.Text?.Contains(Name);
    }
}

