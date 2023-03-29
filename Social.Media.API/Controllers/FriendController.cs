using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socail.Media.Core.Models;
using Socail.Media.Core.Models.Friends;
using Social.Media.API.Commands;

namespace Social.Media.API.Controllers;

[Route("api/friends")]
[ApiController]
public class FriendController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly JwtSettings _jwtSettings;

    public FriendController(IMediator mediator, JwtSettings jwtSettings)
    {
        _mediator = mediator;
        _jwtSettings = jwtSettings;
    }

    [HttpPost]
    public async Task<ActionResult> AddFriend([FromBody] Friends friend)
    {
        var friendToReturn = await _mediator.Send(new AddFriendCommand(friend));
        return Ok(friend);
    }

    [HttpDelete("{friendId:int}")]
    public async Task<ActionResult> RemoveFriendById(int friendId)
    {
        var userToRemove = await _mediator.Send(new RemoveFriendByIdCommand(friendId));
        return Ok();
    }
}