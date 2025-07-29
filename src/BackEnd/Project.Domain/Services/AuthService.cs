using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Project.Domain.Entities.v1;
using Project.Domain.Interfaces.Services;
using Project.Domain.ValueObjects.Auth;
using System.Security.Claims;
using System.Text;

namespace Project.Domain.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Token GenerateToken(User user)
    {
        var accessToken = GenerateAccessToken(user);

        return new Token
        {
            AcccessToken = accessToken
        };
    }

    private string GenerateAccessToken(User user)
    {
        string secretKey = _configuration["Jwt:SecretKey"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("Theme", user.Theme)
                ]),
            Expires = DateTime.Now.AddHours(12),
            SigningCredentials = credentials,
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"]
        };

        return new JsonWebTokenHandler().CreateToken(tokenDescriptor);
    }
}