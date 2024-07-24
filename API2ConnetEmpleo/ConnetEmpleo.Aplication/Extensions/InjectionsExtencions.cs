using CnEmpleo.Infrastructure.Persistences.Interfaces;
using CnEmpleo.Infrastructure.Persistences.Repositories;
using ConnectEmpleo.API.Entities;
using ConnetEmpleo.Aplication.Interface;
using ConnetEmpleo.Aplication.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ConnetEmpleo.Aplication.Extensions
{
   public static class InjectionsExtensions
   {
      public static IServiceCollection AddInjectionApplication(
          this IServiceCollection services, IConfiguration configuration)
      {
         var assembly = typeof(EmpleosContext).Assembly.FullName;
         services.AddSingleton(configuration);

         services.AddAutoMapper(Assembly.GetExecutingAssembly());

         //context db 
         services.AddDbContext<EmpleosContext>(
                 options => options.UseSqlServer(
                     configuration.GetConnectionString("Conexion"),
                     b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

         // unit of work
         services.AddTransient<IUnitOfWork, UnitOfWork>();

         // Configuración de FluentValidation
         services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
         services.AddFluentValidationAutoValidation();

         // Registro de repositorios
         services.AddScoped<ICandidatoRepository, CandidatoRepository>();

         // Registro de aplicaciones
         services.AddScoped<ICandidatoAplication, CandidatoAplication>();


         services.AddScoped<IExperienciaLaboralRepository, ExperienciaLaboralRepository>();

         services.AddScoped<IExperienciaLaboralAplication, ExperienciaLaboralAplication>();

         // Registro de IFormacionAcademicaRepository
         services.AddScoped<IFormacionAcademicaRepository, FormacionAcademicaRepository>();

         // Registro de IFormacionAcademicaAplication
         services.AddScoped<IFormacionAcademicaAplication, FormacionAcademicaAplication>();

         // Registro de IOfertasEmpleoRepository
         services.AddScoped<IOfertasEmpleoRepository, OfertasEmpleoRepository>();

         // Registro de IOferasEmpleoAplication
         services.AddScoped<IOfertaEmpleoAplication, OfertaEmpleoAplication>();

         services.AddScoped<IEmpresaRepository, EmpresaRepository>();

         services.AddScoped<IPostulacionRepository, PostulacionRepository>();

         services.AddScoped<IPostulacionAplication, PostulacionAplication>();

         return services;
      }
   }
}
