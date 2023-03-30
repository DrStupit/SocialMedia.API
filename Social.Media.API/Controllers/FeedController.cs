using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Socail.Media.Core.Models;
using Socail.Media.Core.Models.Posts;
using Social.Media.API.Commands;
using Social.Media.API.Queries;

namespace Social.Media.API.Controllers;

[Route("api/feed")]
[ApiController]
public class FeedController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeedController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("upload")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> AddFeed([FromBody] Feed feed)
    {
        var feedToReturn = await _mediator.Send(new AddFeedItemCommand(feed));
        return Ok(feedToReturn);
    }

    [HttpDelete("/remove/{postId:int}")]
    [Authorize(AuthenticationSchemes =
        Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> DeletePost(int postId)
    {
        var postToRemove = await _mediator.Send(new RemovePostByIdCommand(postId));
        return Ok();
    }

    [HttpPost("update")]
    [Authorize(AuthenticationSchemes =
        Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> UpdatePost(Feed post)
    {
        var postToUpdate = await _mediator.Send(new UpdatePostCommand(post));
        return Ok(postToUpdate);
    }

    [HttpPost("like")]
    [Authorize(AuthenticationSchemes =
        Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> LikePost(Likes like)
    {
        var postToLike = await _mediator.Send(new AddLikeCommand(like));
        return Ok(postToLike);
    }

    [HttpGet("likes")]
    public async Task<ActionResult> GetPostLikes(int postId)
    {
        var postLikes = await _mediator.Send(new GetPostLikesByIdQuery(postId));
        return Ok(postLikes);
    }

    [HttpPost("unlike/{postId:int}/{userId:int}")]
    public async Task<ActionResult> UnlikePost(int postId, int userId)
    {
        var unlikePost = await _mediator.Send(new UnlikePostCommand(postId, userId));
        return Ok();
    }
    
}