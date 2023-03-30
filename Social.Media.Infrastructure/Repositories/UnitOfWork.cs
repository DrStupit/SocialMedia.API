using Social.Media.Application.Interfaces;

namespace Social.Media.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IUserRepository userRepository, 
        IFriendRepository friends,
        IFeedRepository feedRepository, ILikesRepository likes, 
        ICommentRepository comments)
    {
        Users = userRepository;
        Friends = friends;
        Feed = feedRepository;
        Likes = likes;
        Comments = comments;
    }
    public IUserRepository Users { get; }
    public IFriendRepository Friends { get; set; }
    public IFeedRepository Feed { get; set; }
    public ILikesRepository Likes { get; }
    public ICommentRepository Comments { get; }
}