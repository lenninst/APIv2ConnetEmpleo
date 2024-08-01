using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ConnetEmpleo.Aplication.Extensions.Shared
{
    public static class JwtExtensions
   {
      public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
      {
         services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = configuration["JwtSettings:Issuer"],
                   ValidAudience = configuration["JwtSettings:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtSettings:Key"]))
                };
             });
      }
   }
}
