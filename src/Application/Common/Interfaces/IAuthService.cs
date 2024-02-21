using Application.ViewModel;

namespace Application.Common.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }
}
