using AutoMapper;
using Domain.Entities;

namespace Application.TelegramUsers.Queries;

public class GetTelegramUserQuery : IRequest<TelegramUserDto>
{ 
    public long ChatId { get; set; }
}


public class GetTelegramUserQueryHandler : IRequestHandler<GetTelegramUserQuery, TelegramUserDto>
{
    private readonly IDatingAppDbContext _context;
    private readonly IMapper _mapper;

    public GetTelegramUserQueryHandler(IDatingAppDbContext context, IMapper mediator)
    {
        _context = context;
        _mapper = mediator;
    }

    public async Task<TelegramUserDto> Handle(GetTelegramUserQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.TelegramUsers
            .SingleOrDefaultAsync(user => user.ChatId == request.ChatId, cancellationToken);

        if (entity == null || entity.ChatId != request.ChatId)
        {
            throw new NotFoundException(nameof(TelegramUser), request.ChatId);
        }

        return _mapper.Map<TelegramUserDto>(entity);
    }
}

