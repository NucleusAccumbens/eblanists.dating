using Application.TelegramUsers.Commands.CreateTelegramUser;
using MediatR;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Common;

namespace TelegramBot.TelegramCommands.Commands;

public class StartCommand : TelegramCommand
{
    public override string Name => "/start";

    public override Task Execute(Update update, ITelegramBotClient client, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

