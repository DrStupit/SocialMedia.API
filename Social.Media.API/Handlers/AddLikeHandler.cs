using MediatR;
using Social.Media.API.Commands;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class AddLikeHandler : IRequestHandler<AddLikeCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddLikeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<int> Handle(AddLikeCommand request, CancellationToken cancellationToken)
    {
        var result = _unitOfWork.Likes.AddAsync(request.Likes);
        return result;
    }
}