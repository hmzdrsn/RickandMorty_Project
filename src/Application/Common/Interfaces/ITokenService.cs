using Application.ViewModel;

namespace Application.Common.Interfaces
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
    }
}
