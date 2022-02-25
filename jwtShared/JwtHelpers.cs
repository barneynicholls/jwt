using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace jwtShared;

public class JwtHelpers
{
    public static string GenerateToken(JwtOptions jwtConfiguration)
    {
        var key = System.Text.Encoding.ASCII.GetBytes(jwtConfiguration.IssuerSigningKey);

        DateTime expireTime = DateTime.UtcNow.AddDays(1);

        var id = Guid.NewGuid();
        var claims = GetClaims(id, "user1");

        var jwToken = new JwtSecurityToken(
            issuer: jwtConfiguration.ValidIssuer,
            audience: jwtConfiguration.ValidAudience,
            claims: claims,
            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires: new DateTimeOffset(expireTime).DateTime,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

        var token = new JwtSecurityTokenHandler().WriteToken(jwToken);

        return token;
    }

    private static IEnumerable<Claim> GetClaims(Guid id, string userName)
    {
        IEnumerable<Claim> claims = new Claim[]
        {
            new(ClaimTypes.Name, userName),
            new(ClaimTypes.NameIdentifier, "1234"),
            new("Id", id.ToString()),
            new("iss", "https://api.payroc.com"),
            new("iat", "1642101679"),
            new("exp", "1642103295"),
            new("aud", "https://api.payroc.com"),
            new("account_type", "isg"),
            new(ClaimTypes.Role,"LovesARole")
        };
        return claims;
    }
}