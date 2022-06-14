using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TP.Net.Hw4.Application.Interfaces.Repositories;
using TP.Net.Hw4.Application.Interfaces.Services;
using TP.Net.Hw4.Application.Mapping;
using TP.Net.Hw4.Domain.Entity;
using TP.Net.Hw4.Infrastructure.Persistence.Context;
using TP.Net.Hw4.Infrastructure.Repositories;
using TP.Net.Hw4.Infrastructure.Services;

namespace TP.Net.Hw4.Infrastructure.DependencyContainer
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfractructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //DBContext
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<SocialNetworkDbContext>(options => options.UseSqlServer(connectionString));


            //Interface signing.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserMessageRepository, UserMessageRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            //Mapping
            services.AddAutoMapper(typeof(Mapping));


            //Token Configs
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            //Identity Package
            services.AddIdentity<User, UserRole>()
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
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = "localhost:6379";
                opt.InstanceName = "RedisCacheServer";
            });



            return services;
        }
    }
}
