using MediatR;
using Socail.Media.Core.Models;
using Social.Media.API.Queries;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class GetUserByEmailAndPasswordHandler : IRequestHandler<GetUserByEmailAndPassword, User>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserByEmailAndPasswordHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User> Handle(GetUserByEmailAndPassword request, CancellationToken cancellationToken)
        => await _unitOfWork.Users.GetByEmailAndPasswordAsync(request.email, request.password);
}