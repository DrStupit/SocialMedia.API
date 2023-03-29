using MediatR;
using Socail.Media.Core.Models;
using Social.Media.API.Commands;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class AddUserHandler : IRequestHandler<AddUserCommand, User>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Users.AddAsync(request.User);
        return request.User;
    }
}