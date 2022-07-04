using Domain.Entities;
using Domain.Enums;

namespace Application.DatingAppUsers.Commands.CreateDatingAppUser;

public record CreateDatingAppUserCommand : IRequest<Guid>
{
    public Roles Role { get; set; }
}

public class CreateDatingAppUserCommandHendler : IRequestHandler<CreateDatingAppUserCommand, Guid>
{
    private readonly IDatingAppDbContext _context;

    public CreateDatingAppUserCommandHendler(IDatingAppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateDatingAppUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new DatingAppUser()
        {
            Role = request.Role
        };

        await _context.DatingAppUsers
            .AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}


