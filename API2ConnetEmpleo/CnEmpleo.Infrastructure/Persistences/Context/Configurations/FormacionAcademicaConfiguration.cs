using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnEmpleo.Infrastructure.Persistences.Context.Configurations
{
   public class FormacionAcademicaConfiguration : IEntityTypeConfiguration<FormacionAcademica>
   {
      public void Configure (EntityTypeBuilder<FormacionAcademica> builder)
      {
         builder.HasKey(e => e.Id).HasName("PK__formacio__46D6BE8F96D253F2");

         builder.ToTable("formacionAcademica", "mydb");

         //builder.Property(e => e.Id).HasColumnName("idformacionAcademica").ValueGeneratedNever();

         builder.Property(e => e.Id).HasColumnName("IdformacionAcademica");
         builder.Property(e => e.CandidatosFk).HasColumnName("CandidatosFK");
         builder.Property(e => e.FechaFin)
             .HasMaxLength(45)
             .HasColumnName("FechaFin");
         builder.Property(e => e.FechaInicio)
             .HasMaxLength(45)
             .HasColumnName("FechaInicio");
         builder.Property(e => e.Institucion)
             .HasMaxLength(45)
             .HasColumnName("Institucion");
         builder.Property(e => e.Pais)
             .HasMaxLength(45)
             .HasColumnName("Pais");
         builder.Property(e => e.Titulo)
             .HasMaxLength(45)
             .HasColumnName("Titulo");

         builder.HasOne(d => d.CandidatosFkNavigation).WithMany(p => p.FormacionAcademicas)
             .HasForeignKey(d => d.CandidatosFk)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK__formacion__Candi__05D8E0BE");

      }

   }
}
