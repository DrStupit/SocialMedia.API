using MediatR;
using Socail.Media.Core.Models.Friends;
using Social.Media.API.Queries;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class AcceptFriendRequestHandler : IRequestHandler<AcceptFriendRequestQuery, Friends>
{
    private readonly IUnitOfWork _unitOfWork;

    public AcceptFriendRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Friends> Handle(AcceptFriendRequestQuery request, CancellationToken cancellationToken)
    {
        var friendRequest = await _unitOfWork.Friends.AcceptFriendRequest(request.friendId);
        return friendRequest;
    }
}