using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cointhi.Api.UseCases.Token
{
    public class GenerateToken(IConfiguration _configuration) : IGenerateToken
    {
        
        string IGenerateToken.GenerateToken(Guid userId, string email)
        {
            
            var jwtSettings = _configuration.GetSection("Jwt");

            var tokenHandler = new JwtSecurityTokenHandler();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!));

            var expiresInDays = jwtSettings["ExpiresInDays"];

            var claims = new List<Claim> 
            {
                new Claim("id", userId.ToString()),
                new Claim("email", email)
            };

            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingCredentials,
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                Expires = DateTime.UtcNow.AddDays(int.Parse(expiresInDays!)),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
