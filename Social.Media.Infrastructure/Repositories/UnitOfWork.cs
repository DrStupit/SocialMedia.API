using Social.Media.Application.Interfaces;

namespace Social.Media.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IUserRepository userRepository, 
        IFriendRepository friends,
        IFeedRepository feedRepository)
    {
        Users = userRepository;
        Friends = friends;
        Feed = feedRepository;
    }
    public IUserRepository Users { get; }
    public IFriendRepository Friends { get; set; }
    public IFeedRepository Feed { get; set; }
}