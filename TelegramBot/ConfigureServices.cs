using Application.Common.Interfaces;
using Telegram.Bot;
using TelegramBot.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureService
{
    public static IServiceCollection AddTelegramBotServices(this IServiceCollection services)
    {
        services.AddTransient<ITelegramBotClient, TelegramBotClient>(); 

        services.AddSingleton<TelegramBot.Common.TelegramBot>();

        services.AddSingleton<ICurrentUserService, CurrentTelegramBotUserService>();

        return services;
    }
}
