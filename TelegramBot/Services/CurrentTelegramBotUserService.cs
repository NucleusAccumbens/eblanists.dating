using Application.Common.Interfaces;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Services;

public class CurrentTelegramBotUserService : ICurrentUserService
{
    private readonly Update _update;

    public CurrentTelegramBotUserService(Update update)
    {
        _update = update;
    }

    public long? TelegramUserChatId
    {
        get 
        {
            if (_update.Type == UpdateType.Message)
            {
                return _update.Message?.Chat.Id;
            }
            if (_update.Type == UpdateType.CallbackQuery)
            {
                return _update.CallbackQuery?.Message?.Chat.Id;
            }
            if (_update.Type == UpdateType.MyChatMember)
            {
                return _update.MyChatMember?.Chat.Id;
            }
            return default;
        }
    }

    public Guid? DatingAppUserId => null;
}

