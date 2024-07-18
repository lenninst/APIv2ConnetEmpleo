using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConnectEmpleo.API.Entities;

public partial class EmpleosContext : DbContext
{
    public EmpleosContext()
    {
    }

    public EmpleosContext(DbContextOptions<EmpleosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidato> Candidatos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<ExperienciaLaboral> ExperienciaLaborals { get; set; }

    public virtual DbSet<Favorito> Favoritos { get; set; }

    public virtual DbSet<FormacionAcademica> FormacionAcademicas { get; set; }

    public virtual DbSet<OfertasEmpleo> OfertasEmpleos { get; set; }

    public virtual DbSet<Postulacion> Postulaciones { get; set; }


    public virtual DbSet<User> Users { get; set; }


   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    
      base.OnModelCreating(modelBuilder);
   }

}
