namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        long? TelegramUserChatId { get; }
        Guid? DatingAppUserId { get; }
    }
}
