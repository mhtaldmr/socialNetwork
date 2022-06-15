using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TP.Net.Hw.Application.Interfaces.Repositories;
using TP.Net.Hw.Application.Interfaces.Services;
using TP.Net.Hw.Domain.Entity;
using TP.Net.Hw.Infrastructure.Persistence.Context;
using TP.Net.Hw.Infrastructure.Repositories;
using TP.Net.Hw.Infrastructure.Services;

namespace TP.Net.Hw.Infrastructure.DependencyContainer
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
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IReportService, ReportService>();



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


            // Add Hangfire services.
            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("Default"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            services.AddHangfireServer();



            return services;
        }
    }
}
