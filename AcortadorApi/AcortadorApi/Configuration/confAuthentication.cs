using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace AcortadorApi.Configuration
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
