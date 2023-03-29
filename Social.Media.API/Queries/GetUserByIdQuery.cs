using MediatR;
using Socail.Media.Core.Models;

namespace Social.Media.API.Queries;

public record GetUserByIdQuery(int id) : IRequest<User>;
