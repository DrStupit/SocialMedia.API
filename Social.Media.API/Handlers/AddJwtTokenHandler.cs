using MediatR;
using Social.Media.API.Commands;
using Social.Media.Application.Interfaces;

namespace Social.Media.API.Handlers;

public class AddJwtTokenHandler : IRequestHandler<AddJwtTokenCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddJwtTokenHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AddJwtTokenCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Users.InsertJwtToken(request.UserTokens);
        return Unit.Value;
    }
}