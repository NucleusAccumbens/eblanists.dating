using Domain.Enums;

namespace Application.DatingAppUsers.Commands.UpdateDatingAppUser;

public record UpdateDatingAppUserCommand : IRequest
{
    public Guid Id { get; set; }
    public Roles Role { get; set; }
    public bool? IsVegan { get; set; }
    public bool? IsNoncredist { get; set; }
    public bool? IsChildfree { get; set; }
    public bool? IsPansexual { get; set; }
    public bool? IsCosmopolitan { get; set; }
    public bool? IsBdsmLover { get; set; }
    public bool? IsMakeupUser { get; set; }
    public bool? IsHeelsUser { get; set; }
    public bool? IsTattooed { get; set; }
    public bool? IsExistLover { get; set; }
    public bool? ShaveLegs { get; set; }
    public bool? ShaveHead { get; set; }
    public bool? HaveSacred { get; set; }
    public string? OtherInfo { get; set; }
}

public class UpdateDatingAppUserCommandHandler : IRequestHandler<UpdateDatingAppUserCommand>
{
    private readonly IDatingAppDbContext _context;

    public UpdateDatingAppUserCommandHandler(IDatingAppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateDatingAppUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.DatingAppUsers
            .SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException("unknown name", request.Id);
        }

        entity.Role = request.Role;
        entity.IsVegan = request.IsVegan;
        entity.IsNoncredist = request.IsNoncredist;
        entity.IsChildfree = request.IsChildfree;
        entity.IsPansexual = request.IsPansexual;
        entity.IsCosmopolitan = request.IsCosmopolitan;
        entity.IsBdsmLover = request.IsBdsmLover;
        entity.IsMakeupUser = request.IsMakeupUser;
        entity.IsHeelsUser = request.IsHeelsUser;
        entity.IsTattooed = request.IsTattooed;
        entity.IsExistLover = request.IsExistLover;
        entity.ShaveLegs = request.ShaveLegs;
        entity.ShaveHead = request.ShaveHead;
        entity.HaveSacred = request.HaveSacred;
        entity.OtherInfo = request.OtherInfo;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

