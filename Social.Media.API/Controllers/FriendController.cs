using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Socail.Media.Core.Models;
using Socail.Media.Core.Models.Friends;
using Social.Media.API.Commands;
using Social.Media.API.Queries;

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
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> AddFriend([FromBody] Friends friend)
    {
        var friendToReturn = await _mediator.Send(new AddFriendCommand(friend));
        return Ok(friend);
    }

    [HttpGet("{userId:int}")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> GetUserFriendList(int userId)
    {
        var friendList = await _mediator.Send(new GetFriendListByUserIdQuery(userId));
        return Ok(friendList);
    }

    [HttpPost("{friendId:int}")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> AcceptFriendRequest(int friendId)
    {
        var friendRequest = await _mediator.Send(new AcceptFriendRequestQuery(friendId));
        return Ok(friendRequest);
    }
    [HttpDelete("{friendId:int}")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> RemoveFriendById(int friendId)
    {
        var userToRemove = await _mediator.Send(new RemoveFriendByIdCommand(friendId));
        return Ok();
    }
}