using Application.TelegramUsers.Commands.CreateTelegramUser;
using Application.TelegramUsers.Commands.DeleteTelegramUser;
using Application.TelegramUsers.Commands.UpdateTelegramUser;
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

    [HttpPost]
    public async Task<ActionResult<long>> CreateTelegramUser(CreateTelegramUserCommand query)
    {
        if (query.ChatId.ToString().Length < 6)
        {
            return BadRequest();
        }

        return await Mediator.Send(query);
    }

    [HttpPut]
    public async Task<ActionResult<long>> UpdateItemDetails(long chatId, UpdateTelegramUserCommand command)
    {
        if (chatId != command.ChatId)
        {
            return BadRequest();
        }

        return await Mediator.Send(command);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteItemDetails(long chatId)
    {
        await Mediator.Send(new DeleteTelegramUserCommand(chatId));

        return NoContent();
    }
}
