namespace Socail.Media.Core.Models.Posts;

public class Feed
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string Caption { get; set; }
    public string ImageURL { get; set; }
    public DateTime PostDate { get; set; }
    public string Location { get; set; }
    public string FishingMethod { get; set; }
    public int CommentCount { get; set; }
    public int LikeCount { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}