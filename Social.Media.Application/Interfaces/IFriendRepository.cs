using Socail.Media.Core.Models.Friends;

namespace Social.Media.Application.Interfaces;

public interface IFriendRepository 
{
    Task<int> AddFriend(Friends entity);
    Task<int> RemoveFriend(int friendId);
}