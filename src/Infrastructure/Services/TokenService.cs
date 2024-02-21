using Application.Common.Interfaces;
using Application.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,request.Username));

            var claimArray = claims.ToArray();

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]));
            var dateTimeNow = DateTime.Now;
            var expiresDate = dateTimeNow.AddMinutes(30);
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _configuration["AppSettings:ValidIssuer"],
                audience: _configuration["AppSettings:ValidAudience"],
                claims:claimArray,
                notBefore:dateTimeNow,
                expires:expiresDate,
                signingCredentials:new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256)
                );

            return Task.FromResult(new GenerateTokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpireDate =expiresDate
            });
        }
    }
}
