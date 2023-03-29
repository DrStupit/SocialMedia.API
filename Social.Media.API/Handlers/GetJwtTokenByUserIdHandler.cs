using MediatR;
using Socail.Media.Core.Models;
using Social.Media.API.Queries;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class GetJwtTokenByUserIdHandler : IRequestHandler<GetJwtTokenByUserId, UserTokens>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetJwtTokenByUserIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserTokens> Handle(GetJwtTokenByUserId request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Users.GetJwtTokenByUserId(request.userId);
        return result;
    }
}