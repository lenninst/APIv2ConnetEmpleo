using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ConnetEmpleo.Aplication.Extensions.Shared
{
   public static class SwaggerConfiguration
   {
      public static void AddSwaggerConfiguration(this IServiceCollection services)
      {
        services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

        // Configurar el esquema de seguridad para Swagger
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "Ingrese el token JWT en el campo de texto siguiente con el formato: Bearer {token}",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.OperationFilter<AuthorizeOperationFilter>();

     
            // c.AddSecurityRequirement(new OpenApiSecurityRequirement
            // {
            //     {
            //         new OpenApiSecurityScheme
            //         {
            //             Reference = new OpenApiReference
            //             {
            //                 Type = ReferenceType.SecurityScheme,
            //                 Id = "Bearer"
            //             }
            //         },
            //         Array.Empty<string>()
            //     }
            // });
         });
      }

   }
}
