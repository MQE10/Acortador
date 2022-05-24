using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Proyecto1.Configuration
{
    public static class AuthenticationExtensions
    {
        public static AuthenticationBuilder AddConfAuthentication(this IServiceCollection services, ConfigurationManager configuration)
        {

            var valor = configuration["jwt:key"];


            return services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)!
      .AddJwtBearer(options =>
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              IssuerSigningKey = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(valor)),
              ClockSkew = TimeSpan.Zero
          }
      )!;
        }
    }
}
