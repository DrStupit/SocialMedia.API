using MediatR;
using Socail.Media.Core.Models;

namespace Social.Media.API.Queries;

public record GetUserByEmailAndPassword(string email, string password) : IRequest<User>;
