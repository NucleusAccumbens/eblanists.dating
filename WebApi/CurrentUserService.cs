using Application.Common.Interfaces;
using System.Security.Claims;

namespace WebApi;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public long? TelegramUserChatId => Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));

    public Guid? DatingAppUserId => null;
}
