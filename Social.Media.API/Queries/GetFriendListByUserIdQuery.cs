using MediatR;
using Socail.Media.Core.Models.Friends;

namespace Social.Media.API.Queries;

public record GetFriendListByUserIdQuery(int id) : IRequest<List<Friends>>;
