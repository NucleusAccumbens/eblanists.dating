using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.TelegramUsers.Queries;

public class TelegramUserDto : IMapFrom<TelegramUser>
{
    public long ChatId { get; set; }
    public string? Username { get; set; }
    public bool IsAdmin { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TelegramUser, TelegramUserDto>()
            .ForMember(a => a.ChatId, opt => opt.MapFrom(b => b.ChatId))
            .ForMember(a => a.Username, opt => opt.MapFrom(b => b.Username))
            .ForMember(a => a.IsAdmin, opt => opt.MapFrom(b => b.IsAdmin));
    }
}
