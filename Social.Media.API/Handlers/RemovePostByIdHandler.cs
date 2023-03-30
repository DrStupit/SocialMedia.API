using MediatR;
using Social.Media.API.Commands;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class RemovePostByIdHandler : IRequestHandler<RemovePostByIdCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemovePostByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemovePostByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Feed.DeleteAsync(request.postId);
        return Unit.Value;
    }
}