using MediatR;
using Socail.Media.Core.Models.Posts;
using Social.Media.API.Commands;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePostHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<int> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var result = _unitOfWork.Feed.UpdateAsync(request.Feed);
        return result;
    }
}