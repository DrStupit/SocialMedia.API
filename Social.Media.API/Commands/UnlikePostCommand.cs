using MediatR;

namespace Social.Media.API.Commands;

public record UnlikePostCommand(int postId, int userId) : IRequest<Unit>;
