using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnEmpleo.Infrastructure.Persistences.Context.Configurations
{
   public class ExperienciaLaboralConfiguration : IEntityTypeConfiguration<ExperienciaLaboral>
   {
      public void Configure(EntityTypeBuilder<ExperienciaLaboral> builder)
      {
         builder.HasKey(e => e.Id).HasName("PK__experien__796F8DAFCEA750E0");

         builder.ToTable("experienciaLaboral", "mydb");

         builder.Property(e => e.Id).HasColumnName("idexperienciaLaboral");
         builder.Property(e => e.AniosExperiencia).HasColumnName("aniosExperiencia");
         builder.Property(e => e.CandidatosFk).HasColumnName("CandidatosFK");
         builder.Property(e => e.Descripcion)
             .HasMaxLength(100)
             .IsUnicode(false);
         builder.Property(e => e.Establecimiento)
             .HasMaxLength(45)
             .HasColumnName("establecimiento");
         builder.Property(e => e.Puesto)
             .HasMaxLength(45)
             .HasColumnName("puesto");

         builder.HasOne(d => d.CandidatosFkNavigation).WithMany(p => p.ExperienciaLaborals)
             .HasForeignKey(d => d.CandidatosFk)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK__experienc__candi__4222D4EF");

      }
   }
}
