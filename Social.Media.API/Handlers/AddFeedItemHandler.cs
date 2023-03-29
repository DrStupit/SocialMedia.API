using MediatR;
using Socail.Media.Core.Models.Posts;
using Social.Media.API.Commands;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class AddFeedItemHandler : IRequestHandler<AddFeedItemCommand, Feed>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddFeedItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Feed> Handle(AddFeedItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Feed.AddAsync(request.Feed);
        return request.Feed;
    }
}