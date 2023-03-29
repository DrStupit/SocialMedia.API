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

    [HttpGet("{id:int}", Name = "GetUserById")]
    public async Task<ActionResult> GetUserById(int id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));
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
                token = JwtHelper.GenTokenKey(new UserToken()
                {
                    EmailAddress = user.Email,
                    GuidId = Guid.NewGuid(),
                    Id = user.Id,
                }, _jwtSettings);
                user.Token = token.Token;
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