using MediatR;
using Socail.Media.Core.Models.Posts;
using Social.Media.API.Commands;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class AddCommentHandler : IRequestHandler<AddCommentCommand,Comments>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Comments> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Comments.AddAsync(request.Comments);
        return request.Comments;
    }
}