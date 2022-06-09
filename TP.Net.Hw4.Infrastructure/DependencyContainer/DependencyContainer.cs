using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuhammetAliDemir.TP.Net.Hw4.Application.Interfaces;
using MuhammetAliDemir.TP.Net.Hw4.Infrastructure.Context;

namespace MuhammetAliDemir.TP.Net.Hw4.Infrastructure.DependencyContainer
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfractructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Adding the dbcontext for entityframework
            var connectionString = configuration.GetConnectionString("default");
            services.AddDbContext<SocialNetworkDbContext>(options => options.UseSqlServer(connectionString));

            //Signing the implementations of ISocialNetworkDBContext interface.
            services.AddScoped<ISocialNetworkDbContext, SocialNetworkDbContext>();


            return services;
        }
    }
}
