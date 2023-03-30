﻿using MediatR;
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
}