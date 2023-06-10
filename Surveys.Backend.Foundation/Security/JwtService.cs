using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Surveys.Backend.Configurations;

namespace Surveys.Backend.Foundation.Security;

public class JwtService : IJwtService
{
    private readonly JwtConfiguration _jwtConfiguration;


    public JwtService(JwtConfiguration jwtConfiguration)
    {
        _jwtConfiguration = jwtConfiguration;
    }


    public string CreateToken(Guid id, string email, string name)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentNullException(nameof(email));
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(email));
        }

        var key = CreateSymmetricSecurityKey(_jwtConfiguration.Secret);
        var credentials = CreateSigningCredentials(key);

        var claims = CreateClaims(id, email, name);

        var tokenDescriptor = CreateTokenDescriptor(claims.ToList(), credentials, JwtConfiguration.ExpireDaysLimit);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }


    public static SymmetricSecurityKey CreateSymmetricSecurityKey(string secret)
        => new (Encoding.UTF8.GetBytes(secret));

    private static SigningCredentials CreateSigningCredentials(SecurityKey key)
        => new (key, SecurityAlgorithms.HmacSha256Signature);

    private static SecurityTokenDescriptor CreateTokenDescriptor(
        IReadOnlyCollection<Claim> claims,
        SigningCredentials credentials,
        int expireDaysLimit)
    {
        return new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(expireDaysLimit),
            SigningCredentials = credentials
        };
    }

    private static IReadOnlyCollection<Claim> CreateClaims(Guid id, string email, string name)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentNullException(nameof(email));
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(email));
        }

        return new List<Claim>
        {
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Sub, email),
            new (JwtRegisteredClaimNames.Name, name),
            new (JwtRegisteredClaimNames.Email, email),
            new (JwtRegisteredClaimNames.Id, id.ToString())
        };
    }
}