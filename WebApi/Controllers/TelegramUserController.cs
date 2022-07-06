using Application.TelegramUsers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
public class TelegramUserController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<TelegramUserDto>> GetTelegramUser([FromQuery] GetTelegramUserQuery query)
    {
        return await Mediator.Send(query);
    }
}
