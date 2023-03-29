using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Socail.Media.Core.Models;
using Socail.Media.Core.Models.Posts;
using Social.Media.API.Commands;

namespace Social.Media.API.Controllers;

[Route("api/feed")]
[ApiController]
public class FeedController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly JwtSettings _jwtSettings;

    public FeedController(IMediator mediator, JwtSettings jwtSettings)
    {
        _mediator = mediator;
        _jwtSettings = jwtSettings;
    }
    
    [HttpPost("upload")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> AddFeed([FromBody] Feed feed)
    {
        var feedToReturn = await _mediator.Send(new AddFeedItemCommand(feed));
        return Ok(feedToReturn);
    }
}