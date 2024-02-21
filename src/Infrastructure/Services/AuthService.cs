using Application.Common.Interfaces;
using Application.ViewModel;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        readonly ITokenService _tokenService;
        readonly IConfiguration _configuration;

        public AuthService(ITokenService tokenService, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            string username = _configuration["AppSettings:username"];
            string password = _configuration["AppSettings:password"];
            LoginResponse response = new();
            if (username == loginRequest.Username && password == loginRequest.Password)
            {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Username = username });

                response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
                response.AuthenticateResult = true;
                response.AuthToken = generatedTokenInformation.Token;
                response.State = "logged in successfully";
            }
            return response;
        }
    }
}