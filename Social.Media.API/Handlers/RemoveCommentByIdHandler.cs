using MediatR;
using Social.Media.API.Commands;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class RemoveCommentByIdHandler : IRequestHandler<RemoveCommentByIdCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCommentByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveCommentByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Comments.DeleteAsync(request.commentId);
        return Unit.Value;
    }
}