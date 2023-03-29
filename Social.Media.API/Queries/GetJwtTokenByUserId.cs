using MediatR;
using Socail.Media.Core.Models;

namespace Social.Media.API.Queries;

public record GetJwtTokenByUserId(int userId) : IRequest<UserTokens>;
