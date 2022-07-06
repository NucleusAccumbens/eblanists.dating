using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace TelegramBot.Common;

public class TelegramBot
{
    private readonly IConfiguration _configuration;
    private ITelegramBotClient? _botClient;

    public TelegramBot(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<ITelegramBotClient> GetBot()
    {
        if (_botClient != null)
        {
            return _botClient;
        }

        _botClient = new TelegramBotClient(_configuration.GetValue<string>("Token"));

        var hook = $"{_configuration.GetValue<string>("Url")}api/message/update";
        await _botClient.SetWebhookAsync(hook);

        return _botClient;
    }
}

