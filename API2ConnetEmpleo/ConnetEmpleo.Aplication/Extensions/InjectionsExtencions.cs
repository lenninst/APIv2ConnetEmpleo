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

         services.AddDbContext<EmpleosContext>(
                 options => options.UseSqlServer(
                     configuration.GetConnectionString("Conexion"),
                     b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

         services.AddTransient<IUnitOfWork, UnitOfWork>();

         services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
         services.AddFluentValidationAutoValidation();

         services.AddScoped<ICandidatoRepository, CandidatoRepository>();

         services.AddScoped<ICandidatoAplication, CandidatoAplication>();


         services.AddScoped<IExperienciaLaboralRepository, ExperienciaLaboralRepository>();

         services.AddScoped<IExperienciaLaboralAplication, ExperienciaLaboralAplication>();

         services.AddScoped<IFormacionAcademicaRepository, FormacionAcademicaRepository>();

         services.AddScoped<IFormacionAcademicaAplication, FormacionAcademicaAplication>();

         services.AddScoped<IOfertasEmpleoRepository, OfertasEmpleoRepository>();

         services.AddScoped<IOfertaEmpleoAplication, OfertaEmpleoAplication>();

         services.AddScoped<IEmpresaRepository, EmpresaRepository>();

         services.AddScoped<IPostulacionRepository, PostulacionRepository>();

         services.AddScoped<IPostulacionAplication, PostulacionAplication>();

         services.AddScoped<IUserRepository, UserRepository>();
         services.AddScoped<IUserAplication, UserAplication>();

         return services;
      }
   }
}
