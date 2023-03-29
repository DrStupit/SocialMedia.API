using MediatR;
using Social.Media.API.Queries;
using Socail.Media.Core.Models;
using Socail.Media.Core.Models.Friends;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class GetFriendListByUserIdHandler : IRequestHandler<GetFriendListByUserIdQuery, List<Friends>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetFriendListByUserIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Friends>> Handle(GetFriendListByUserIdQuery request, CancellationToken cancellationToken)
        => await _unitOfWork.Friends.GetUsersFriends(request.id);
}
