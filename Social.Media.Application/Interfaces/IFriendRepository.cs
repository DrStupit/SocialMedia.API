using Socail.Media.Core.Models.Friends;

namespace Social.Media.Application.Interfaces;

public interface IFriendRepository 
{
    Task<int> AddFriend(Friends entity);
    Task<int> RemoveFriend(int friendId);
    Task<List<Friends>> GetUsersFriends(int userId);
    Task<Friends> AcceptFriendRequest(int friendId);
}