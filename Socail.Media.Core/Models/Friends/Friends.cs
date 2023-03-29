namespace Socail.Media.Core.Models.Friends;

public class Friends
{
    public int FriendId { get; set; }
    public int UserId { get; set; }
    public int FriendUserId { get; set; }
    public bool IsAccepted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}