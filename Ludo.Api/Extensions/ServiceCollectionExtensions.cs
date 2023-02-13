using Ludo.Core.Interfaces;
using Ludo.Core.Services;
using Ludo.Infra.AuthServices;
using Ludo.Infra.Persistence.Repositories;
using Ludo.Infra.Services;

namespace Ludo.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
