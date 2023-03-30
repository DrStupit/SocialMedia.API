using MediatR;
using Socail.Media.Core.Models.Posts;
using Social.Media.API.Queries;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class GetPostLikesByIdHandler : IRequestHandler<GetPostLikesByIdQuery, List<Likes>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPostLikesByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Likes>> Handle(GetPostLikesByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Likes.GetPostLikes(request.postId);
        return result;
    }
}