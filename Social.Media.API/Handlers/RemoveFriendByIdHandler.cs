using MediatR;
using Social.Media.API.Commands;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class RemoveFriendByIdHandler : IRequestHandler<RemoveFriendByIdCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveFriendByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveFriendByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Friends.RemoveFriend(request.friendId);
        return Unit.Value;
    }
}