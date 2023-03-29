namespace Socail.Media.Core.Models;

public class UserToken
{
    public string Token {
        get;
        set;
    }
    public TimeSpan Validaty {
        get;
        set;
    }
    public string RefreshToken {
        get;
        set;
    }
    public string EmailAddress {
        get;
        set;
    }

    public int Id { get; set; }
    public Guid GuidId {
        get;
        set;
    }
    public DateTime ExpiredTime {
        get;
        set;
    }
}