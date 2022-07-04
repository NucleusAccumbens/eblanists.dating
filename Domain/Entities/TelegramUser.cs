namespace Domain.Entities
{
    public class TelegramUser : BaseAuditableEntity
    {
        public long ChatId { get; set; }
        public string? Username { get; set; }
        public bool IsAdmin { get; set; }
        public bool? AddedToAttachmentMenu { get; set; }
        public Guid? DatingAppUserId { get; set; }
    }
}
