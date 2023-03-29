using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Socail.Media.Core.Models;

namespace Social.Media.Infrastructure.Helpers;

public static class JwtHelper
{
    public static IEnumerable<Claim> GetClaims(this UserToken userAccounts, Guid id)
    {
        IEnumerable<Claim> claims = new Claim[]
        {
            new Claim("Id", userAccounts.Id.ToString()),
            new Claim(ClaimTypes.Name, userAccounts.EmailAddress),
            new Claim(ClaimTypes.Email, userAccounts.EmailAddress),
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
        };
        return claims;
    }

    public static IEnumerable<Claim> GetClaims(this UserToken userAccounts, out Guid Id)
    {
        Id = Guid.NewGuid();
        return GetClaims(userAccounts, Id);
    }

    public static UserToken GenTokenKey(UserToken model, JwtSettings jwtSettings)
    {
        try
        {
            var userToken = new UserToken();
            if (model == null) throw new ArgumentException(nameof(model));
            // Get secret
            var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
            Guid id = Guid.Empty;
            DateTime expireTime = DateTime.UtcNow.AddDays(1);
            userToken.Validaty = expireTime.TimeOfDay;
            var jwtToken = new JwtSecurityToken(issuer: jwtSettings.ValidIssuer,
                audience: jwtSettings.ValidAudience,
                claims: GetClaims(model, out id),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(expireTime).DateTime,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );
            userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            userToken.EmailAddress = model.EmailAddress;
            userToken.Id = model.Id;
            userToken.GuidId = id;
            return userToken;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}