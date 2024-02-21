using Application.Common.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Registrations
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICharacterService,CharacterService>();
            services.AddTransient<IEpisodeService,EpisodeService>();
            services.AddTransient<ILocationService,LocationService>();
            services.AddTransient<IOriginService,OriginService>();

            services.AddTransient<IAuthService,AuthService>();
            services.AddTransient<ITokenService,TokenService>();
        }
    }
}
