using System.Reflection;
using Application.Common.Behaviours;
using Application.TelegramUsers.Commands.CreateTelegramUser;
using FluentValidation;


namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssemblyContaining<CreateTelegramUserCommandChatIdValidator>();
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}

