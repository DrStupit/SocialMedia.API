using MediatR;
using Microsoft.AspNetCore.Mvc;
using Socail.Media.Core.Models;
using Social.Media.API.Commands;
using Social.Media.API.Queries;
using Social.Media.Infrastructure.Helpers;

namespace Social.Media.API.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly JwtSettings _jwtSettings;

    public UserController(IMediator mediator, JwtSettings jwtSettings)
    {
        _mediator = mediator;
        _jwtSettings = jwtSettings;
    }

    [HttpPost]
    public async Task<ActionResult> AddUser([FromBody] User user)
    {
        var userToReturn = await _mediator.Send(new AddUserCommand(user));
        return Ok(user);
    }

    [HttpGet]
    [Route("login")]
    public async Task<ActionResult> UserLogin([FromBody] UserLoginRequest ulr)
    {
        try
        {
            var token = new UserToken();
            var user = await _mediator.Send(new GetUserByEmailAndPassword(ulr.Email, ulr.Password));

            if (user != null)
            {
                var retrievedToken = await _mediator.Send(new GetJwtTokenByUserId(user.Id));
                if (retrievedToken != null)
                {
                    if (retrievedToken.Expiration_Time > DateTime.Now)
                    {
                        //this is a valid token
                        user.Token = retrievedToken.Token;
                    }
                    else
                    {
                        token = JwtHelper.GenTokenKey(new UserToken()
                        {
                            EmailAddress = user.Email,
                            GuidId = Guid.NewGuid(),
                            Id = user.Id,
                        }, _jwtSettings);
                
                        var jwtUser = new UserTokens
                        {
                            Token = token.Token,
                            Expiration_Time = DateTime.UtcNow.AddDays(1),
                            UserId = user.Id
                        };
                        await _mediator.Send(new AddJwtTokenCommand(jwtUser));
                        user.Token = token.Token;
                    }
                }
                else
                {
                    token = JwtHelper.GenTokenKey(new UserToken()
                    {
                        EmailAddress = user.Email,
                        GuidId = Guid.NewGuid(),
                        Id = user.Id,
                    }, _jwtSettings);
                
                    var jwtUser = new UserTokens
                    {
                        Token = token.Token,
                        Expiration_Time = DateTime.UtcNow.AddDays(1),
                        UserId = user.Id
                    };
                    await _mediator.Send(new AddJwtTokenCommand(jwtUser));
                    user.Token = token.Token;
                }
            }
            else
            {
                return BadRequest($"Incorrect Login Details");
            }
            return Ok(user);
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}