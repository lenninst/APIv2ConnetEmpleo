using CnEmpleo.Infrastructure.Persistences.Interfaces;
using CnEmpleo.Infrastructure.Persistences.Repositories;
using ConnectEmpleo.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CnEmpleo.Infrastructure.Extensions
{
   public static class InjectionExtensions
   {
      public static IServiceCollection AddInyectionInfrastructure(
         this IServiceCollection services, IConfiguration configuration
         )
      {
         var assembly = typeof(EmpleosContext).Assembly.FullName;

         services.AddDbContext<EmpleosContext>(
             options => options.UseSqlServer(
                 configuration.GetConnectionString("Conexion"),
                 sqlOptions => sqlOptions.MigrationsAssembly(assembly))
         );

         services.AddTransient<IUnitOfWork, UnitOfWork>();
         services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

         return services;
      }
   }
}
