using MediatR;

namespace Social.Media.API.Commands;

public record RemovePostByIdCommand(int postId) : IRequest<Unit>;

