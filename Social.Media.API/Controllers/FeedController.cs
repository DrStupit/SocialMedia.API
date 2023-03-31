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
    private readonly IWebHostEnvironment _env;

    public FeedController(IMediator mediator, IWebHostEnvironment env)
    {
        _mediator = mediator;
        _env = env;
    }
    
    [HttpPost("upload")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> AddFeed([FromForm] FeedRequest feed)
    {
        if (feed.ImageFile == null || feed.ImageFile.Length == 0)
        {
            return BadRequest($"Please select and image to upload");
        }

        var fileName = Guid.NewGuid().ToString() + "_" + feed.UserId;
                       Path.GetExtension(feed.ImageFile.FileName);
        var filePath = Path.Combine("C:\\FishbookRepo", "Uploads", fileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await feed.ImageFile.CopyToAsync(stream);
        }
        var imageUrl = "/Uploads/" + fileName;

        var feedItem = new Feed()
        {
            UserId = feed.UserId,
            Caption = feed.Caption,
            ImageURL = imageUrl,
            Location = feed.Location,
            FishingMethod = feed.FishingMethod,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            CommentCount = 0,
            LikeCount = 0,
            PostDate = DateTime.Now
        };
        
        var feedToReturn = await _mediator.Send(new AddFeedItemCommand(feedItem));
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
    [Authorize(AuthenticationSchemes =
        Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> UnlikePost(int postId, int userId)
    {
        var unlikePost = await _mediator.Send(new UnlikePostCommand(postId, userId));
        return Ok();
    }

    [HttpPost("comment")]
    [Authorize(AuthenticationSchemes =
        Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> Comment(Comments comment)
    {
        var commentPost = await _mediator.Send(new AddCommentCommand(comment));
        return Ok(commentPost);
    }

    [HttpDelete("delete/comment")]
    [Authorize(AuthenticationSchemes =
        Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> DeleteComment(int commentId)
    {
        var deleteComment = await _mediator.Send(new RemoveCommentByIdCommand(commentId));
        return Ok();
    }
    

}