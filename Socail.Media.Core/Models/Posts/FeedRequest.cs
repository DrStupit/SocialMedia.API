using Microsoft.AspNetCore.Http;

namespace Socail.Media.Core.Models.Posts;

public class FeedRequest
{
    public int UserId { get; set; }
    public string Caption { get; set; }
    public string Location { get; set; }
    public string FishingMethod { get; set; }
    public IFormFile ImageFile { get; set; }
}