namespace Socail.Media.Core.Models.Posts;

public class Likes
{
    public int LikeID { get; set; }
    public int PostID { get; set; }
    public int UserID { get; set; }
    public int CommentID { get; set; }
    public DateTime LikeDate { get; set; }
}