namespace Socail.Media.Core.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get;}
    public string? Password { get; set; }
    public bool NewsletterSubscription { get; set; }
    public string? ProfilePic { get; set; } // this will be a base64 string
    public string? CoverPic { get; set; }
    public string? Gender { get; set; }
    public string? CellPhoneNumber { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public string? Token { get; set; }
}