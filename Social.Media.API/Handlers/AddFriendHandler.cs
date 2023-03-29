using MediatR;
using Socail.Media.Core.Models.Friends;
using Social.Media.API.Commands;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class AddFriendHandler : IRequestHandler<AddFriendCommand, Friends>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddFriendHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Friends> Handle(AddFriendCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Friends.AddFriend(request.Friends);
        return request.Friends;
    }
}