
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ConnetEmpleo.Aplication.Extensions.Shared
{
  public class AuthorizeOperationFilter : IOperationFilter
  {
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Verifica si el método de la operación tiene el atributo [Authorize]
        var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            .OfType<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>()
            .Any() ||
            context.MethodInfo.GetCustomAttributes(true)
            .OfType<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>()
            .Any();

        if (hasAuthorize)
        {
            operation.Security ??= new List<OpenApiSecurityRequirement>();
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        }
    }
  }
}
