using MediatR;

namespace Social.Media.API.Commands;

public record RemoveFriendByIdCommand(int friendId) : IRequest<Unit>;
