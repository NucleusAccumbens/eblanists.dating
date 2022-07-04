using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var telegramUserChatId = _currentUserService.TelegramUserChatId ?? default;
        var datingAppUserId = _currentUserService.DatingAppUserId ?? default;

        _logger.LogInformation("eblanist.dating request: {Name} {@TelegramUserChatId} {@UserId}  {@Request}",
            requestName, telegramUserChatId, datingAppUserId, request);

        return Task.CompletedTask;
    }
}

