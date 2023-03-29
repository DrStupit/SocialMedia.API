using MediatR;
using Socail.Media.Core.Models;
using Social.Media.API.Queries;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserByIdHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        => await _unitOfWork.Users.GetByIdAsync(request.id);
}