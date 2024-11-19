#nullable disable
using Microsoft.Extensions.Configuration;
using la_tegav.Domain.Entities;
using la_tegav.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace la_tegav.Persistence.Repositories;

public class TokenRepository : ITokenService
{

    private readonly IConfiguration _configuration;

    public TokenRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        Claim[] claims =
        [
            new Claim("username", user.UserName),
            new Claim("id", user.Id.ToString()),
            new Claim("email", user.Email)
        ];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ISHDGFyugas3434JHjigjdiodjfhijsdfioSADJFIOJ"));

        var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            audience: _configuration["JwtSettings:Audience"],
            issuer: _configuration["JwtSettings:Issuer"],
            expires: DateTime.Now.AddHours(24),
            claims: claims,
            signingCredentials: signInCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
