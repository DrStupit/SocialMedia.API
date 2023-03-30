namespace Socail.Media.Core.Models.Posts;

public class Comments
{
    public int CommentID { get; set; }
    public int PostID { get; set; }
    public int UserID { get; set; }
    public string CommentText { get; set; }
    public DateTime CommentDate { get; set; }
    public int ParentCommentID { get; set; }
}