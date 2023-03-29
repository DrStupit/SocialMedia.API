using Social.Media.Application.Interfaces;

namespace Social.Media.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IUserRepository userRepository)
    {
        Users = userRepository;
    }
    public IUserRepository Users { get; }
}