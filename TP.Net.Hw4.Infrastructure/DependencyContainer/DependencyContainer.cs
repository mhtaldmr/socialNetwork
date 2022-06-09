using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MuhammetAliDemir.TP.Net.Hw4.Application.Interfaces;
using MuhammetAliDemir.TP.Net.Hw4.Infrastructure.Context;
using System.Text;

namespace MuhammetAliDemir.TP.Net.Hw4.Infrastructure.DependencyContainer
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfractructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            //DBContext
            var connectionString = configuration.GetConnectionString("default");
            services.AddDbContext<SocialNetworkDbContext>(options => options.UseSqlServer(connectionString));


            //Interface signing.
            services.AddScoped<ISocialNetworkDbContext, SocialNetworkDbContext>();


            //TokenValidationParameter Object
            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = configuration["JWT:Audience"],
                ValidIssuer = configuration["JWT:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                ClockSkew = TimeSpan.Zero
            };

            //JWT Bearer configurations
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opt => opt.TokenValidationParameters = tokenValidationParameters);


            return services;
        }
    }
}
