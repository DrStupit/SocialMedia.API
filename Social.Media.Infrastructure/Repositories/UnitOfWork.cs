using Social.Media.Application.Interfaces;

namespace Social.Media.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IUserRepository userRepository, 
        IFriendRepository friends)
    {
        Users = userRepository;
        Friends = friends;
    }
    public IUserRepository Users { get; }
    public IFriendRepository Friends { get; set; }
}