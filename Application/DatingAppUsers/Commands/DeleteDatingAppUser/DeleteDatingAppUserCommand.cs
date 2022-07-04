namespace Application.DatingAppUsers.Commands.DeleteDatingAppUser;

public record DeleteDatingAppUserCommand : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteDatingAppUserCommandHandler : IRequestHandler<DeleteDatingAppUserCommand>
{
    private readonly IDatingAppDbContext _context;

    public DeleteDatingAppUserCommandHandler(IDatingAppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteDatingAppUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.DatingAppUsers
            .SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException("unknown name", request.Id);
        }

        _context.DatingAppUsers
            .Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}