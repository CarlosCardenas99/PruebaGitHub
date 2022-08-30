using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Security;
using Paltarumi.Acopio.Balanza.Repository.Data;
using System.Text;

namespace Paltarumi.Acopio.Balanza.Apis.Security
{
    public static class SecurityServiceCollectionExtensions
    {
        public static IServiceCollection UseSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            #region SecurityDbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddSqlServer<SecurityDbContext>(connectionString, b => b.MigrationsAssembly("Paltarumi.Acopio.Balanza.Apis"));
            #endregion

            #region IdentityOptions
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                if (configuration.GetValue<bool>("SignInOptions:LockoutEnabled"))
                {
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.MaxFailedAccessAttempts = configuration.GetValue<int>("SignInOptions:LockoutMaxFailedAccessAttempts");
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(configuration.GetValue<int>("SignInOptions:LockoutDefaultTimeSpanInMinutes"));
                }
            });
            #endregion

            #region ApplicationCookie
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                // Identity Paths
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            #endregion

            #region Identity
            services
                .AddIdentity<Entity.ApplicationUser, Entity.ApplicationRole>(config =>
                {
                    //config.Tokens.PasswordResetTokenProvider = ResetPasswordTokenProvider.ProviderKey;
                    config.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddDefaultTokenProviders();
            #endregion

            #region Authentication
            var validIssuer = configuration.GetValue<string>("SecurityOptions:Issuer");
            var validAudience = configuration.GetValue<string>("SecurityOptions:Audience");
            var securityKey = configuration.GetValue<string>("SecurityOptions:SecurityKey");

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = validAudience,
                        ValidIssuer = validIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
                    };
                });
            #endregion

            #region UserIdentity
            services.AddScoped<IUserIdentity, UserIdentity>();
            #endregion

            return services;
        }
    }
}
