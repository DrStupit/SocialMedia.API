using MediatR;
using Socail.Media.Core.Models;

namespace Social.Media.API.Commands;

public record AddUserCommand(User User) : IRequest<User>;
