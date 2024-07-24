using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnEmpleo.Infrastructure.Persistences.Context.Configurations
{
   public class PostulacionConfiguration : IEntityTypeConfiguration<Postulacion>
   {
      public void Configure(EntityTypeBuilder<Postulacion> builder)
      {

         builder.HasKey(e => e.Id).HasName("PK__Postulac__37EBAEC17E6F4DFB");

         builder.ToTable("Postulaciones", "mydb");

         builder.Property(e => e.Id).HasColumnName("IdPostulaciones");

         builder.Property(e => e.CandidatosFk).HasColumnName("CandidatosFK");
         builder.Property(e => e.EstadoPostulacion)
             .HasMaxLength(50)
             .IsUnicode(false);
         builder.Property(e => e.OfertasEmpleosFk).HasColumnName("OfertasEmpleosFK");

         builder.HasOne(d => d.CandidatosFkNavigation).WithMany(p => p.Postulaciones)
             .HasForeignKey(d => d.CandidatosFk)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK__Postulaci__Candi__1BC821DD");

         builder.HasOne(d => d.OfertasEmpleosFkNavigation).WithMany(p => p.Postulaciones)
             .HasForeignKey(d => d.OfertasEmpleosFk)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK__Postulaci__Ofert__1CBC4616");

      }
   }
}
