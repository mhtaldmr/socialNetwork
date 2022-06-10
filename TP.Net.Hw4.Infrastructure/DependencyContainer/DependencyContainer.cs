using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using TP.Net.Hw4.Application.Interfaces.Repositories;
using TP.Net.Hw4.Domain.Entity;
using TP.Net.Hw4.Infrastructure.Context;
using TP.Net.Hw4.Infrastructure.Services;
using TP.Net.Hw4.Infrastructure.Repositories;
using TP.Net.Hw4.Infrastructure.MappingProfile;
using Microsoft.IdentityModel.Tokens;

namespace TP.Net.Hw4.Infrastructure.DependencyContainer
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfractructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            //DBContext
            var connectionString = configuration.GetConnectionString("default");
            services.AddDbContext<SocialNetworkDbContext>(options => options.UseSqlServer(connectionString));


            //Interface signing.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            //Mapping
            services.AddAutoMapper(typeof(Mapping));
            
            
            //Token Configs
            services.AddScoped<TokenGenerator>();

            services.AddIdentity<User,UserRole>()
                    .AddEntityFrameworkStores<SocialNetworkDbContext>()
                    .AddDefaultTokenProviders();


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


            //InMemoryCaching
            services.AddMemoryCache();

            //DistributedCaching //Redis
            services.AddStackExchangeRedisCache(options =>
            {
                options.InstanceName = "RedisCacheServer";
                options.Configuration = "localhost";
            });



            return services;
        }
    }
}
