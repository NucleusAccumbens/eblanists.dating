namespace Application.TelegramUsers.Commands.DeleteTelegramUser
{
    public record DeleteTelegramUserCommand(long СhatId) : IRequest;

    public class DeleteTelegramUserCommandHandler : IRequestHandler<DeleteTelegramUserCommand>
    {
        private readonly IDatingAppDbContext _context;

        public DeleteTelegramUserCommandHandler(IDatingAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTelegramUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TelegramUsers
                .SingleOrDefaultAsync(u => u.ChatId == request.СhatId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException("unknown name", request.СhatId);
            }

            _context.TelegramUsers
                .Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
