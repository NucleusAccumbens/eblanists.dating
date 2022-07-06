namespace Application.TelegramUsers.Commands.CreateTelegramUser;

public record CreateTelegramUserCommand : IRequest<long>
{
    public long ChatId { get; init; }
    public string? Username { get; init; }
}

public class CreateTelegramUserCommandHandler : IRequestHandler<CreateTelegramUserCommand, long>
{
    private readonly IDatingAppDbContext _context;

    public CreateTelegramUserCommandHandler(IDatingAppDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateTelegramUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.TelegramUser()
        {
            ChatId = request.ChatId,
            Username = request.Username,
            IsAdmin = false,
        };

        await _context.TelegramUsers
            .AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.ChatId;
    }
}

