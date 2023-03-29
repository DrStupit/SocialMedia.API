using MediatR;
using Socail.Media.Core.Models.Friends;

namespace Social.Media.API.Queries;

public record AcceptFriendRequestQuery(int friendId) : IRequest<Friends>;