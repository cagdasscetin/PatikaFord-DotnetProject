using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BirdApi.Web.Extension;

public static class StartUpCustomAuthentication
{
    public static void AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = true;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true, // default True
                ValidIssuer = Startup.JwtConfig.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Startup.JwtConfig.Secret)),
                ValidAudience = Startup.JwtConfig.Audience,
                ValidateAudience = false, // default True
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(2)
            };
        });
    }
}
