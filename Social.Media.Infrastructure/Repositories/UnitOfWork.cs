using Social.Media.Application.Interfaces;

namespace Social.Media.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IUserRepository userRepository, 
        IFriendRepository friends,
        IFeedRepository feedRepository, ILikesRepository likes)
    {
        Users = userRepository;
        Friends = friends;
        Feed = feedRepository;
        Likes = likes;
    }
    public IUserRepository Users { get; }
    public IFriendRepository Friends { get; set; }
    public IFeedRepository Feed { get; set; }
    public ILikesRepository Likes { get; }
}