using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnEmpleo.Infrastructure.Persistences.Context.Configurations
{
   public class FormacionAcademicaConfiguration : IEntityTypeConfiguration<FormacionAcademica>
   {
      public void Configure (EntityTypeBuilder<FormacionAcademica> builder)
      {
         builder.HasKey(e => e.Id).HasName("PK__formacio__476D62508370E4A2");

         builder.ToTable("formacionAcademica", "mydb");

         //builder.Property(e => e.Id).HasColumnName("idformacionAcademica").ValueGeneratedNever();

         builder.Property(e => e.Id).HasColumnName("idformacionAcademica");
         builder.Property(e => e.CandidatosFk).HasColumnName("CandidatosFK");
         builder.Property(e => e.FechaFin)
             .HasMaxLength(45)
             .HasColumnName("fechaFin");
         builder.Property(e => e.FechaInicio)
             .HasMaxLength(45)
             .HasColumnName("fechaInicio");
         builder.Property(e => e.Institucion)
             .HasMaxLength(45)
             .HasColumnName("institucion");
         builder.Property(e => e.Pais)
             .HasMaxLength(45)
             .HasColumnName("pais");
         builder.Property(e => e.Titulo)
             .HasMaxLength(45)
             .HasColumnName("titulo");

         builder.HasOne(d => d.CandidatosFkNavigation).WithMany(p => p.FormacionAcademicas)
             .HasForeignKey(d => d.CandidatosFk)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK__formacion__candi__3F466844");

      }

   }
}
