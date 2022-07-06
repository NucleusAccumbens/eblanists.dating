using System.Security.Claims;
using Application.Common.Interfaces;

namespace CleanArchitecture.WebUI.Services;

public class CurrentUserService : ICurrentUserService
{

    public long? TelegramUserChatId => throw new NotImplementedException();

    public Guid? DatingAppUserId => throw new NotImplementedException();
}
