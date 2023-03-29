namespace Socail.Media.Core.Models;

public class UserTokens
{
    public int TokenId { get; set; }
    public int UserId { get; set; }
    public string Token { get; set; }
    public DateTime Expiration_Time { get; set; }
}