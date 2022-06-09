using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MuhammetAliDemir.TP.Net.Hw4.Application.DependencyContainer
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {


            return services;
        }

    }
}
