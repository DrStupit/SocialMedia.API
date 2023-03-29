using MediatR;
using Socail.Media.Core.Models;

namespace Social.Media.API.Commands;

public record AddJwtTokenCommand(UserTokens UserTokens) : IRequest<Unit>;
