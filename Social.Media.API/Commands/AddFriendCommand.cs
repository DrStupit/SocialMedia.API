using MediatR;
using Socail.Media.Core.Models.Friends;

namespace Social.Media.API.Commands;

public record AddFriendCommand(Friends Friends) : IRequest<Friends>;
