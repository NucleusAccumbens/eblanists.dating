namespace Application.TelegramUsers.Commands.UpdateTelegramUser
{
    public record UpdateTelegramUserCommand : IRequest
    {
        public long ChatId { get; set; }
        public string? Username { get; set; }
        public bool IsAdmin { get; set; }
        public bool? AddedToAttachmentMenu { get; set; }
        public Guid? DatingAppUserId { get; set; }
    }

    public class UpdateTelegramUserCommandHandler : IRequestHandler<UpdateTelegramUserCommand>
    {
        private readonly IDatingAppDbContext _context;

        public UpdateTelegramUserCommandHandler(IDatingAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTelegramUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TelegramUsers
                .SingleOrDefaultAsync(u => u.ChatId == request.ChatId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException("unknown name", request.ChatId);
            }

            entity.Username = request.Username;
            entity.IsAdmin = request.IsAdmin;
            entity.AddedToAttachmentMenu = request.AddedToAttachmentMenu;
            entity.DatingAppUserId = request.DatingAppUserId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
