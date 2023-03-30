using MediatR;
using Social.Media.API.Commands;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class UnlikePostHandler: IRequestHandler<UnlikePostCommand,Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UnlikePostHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UnlikePostCommand request, CancellationToken cancellationToken)
    {
         await _unitOfWork.Likes.UnlikePost(request.postId, request.userId);
         return Unit.Value;
    }
}