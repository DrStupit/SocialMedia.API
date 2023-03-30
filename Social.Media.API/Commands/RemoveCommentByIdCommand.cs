using MediatR;

namespace Social.Media.API.Commands;

public record RemoveCommentByIdCommand(int commentId) : IRequest<Unit>;
