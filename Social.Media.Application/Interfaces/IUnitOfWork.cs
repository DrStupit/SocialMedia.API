namespace Social.Media.Application.Interfaces;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IFriendRepository Friends { get; set; }
    public IFeedRepository Feed { get; set; }
    ILikesRepository Likes { get; }
}