using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnEmpleo.Infrastructure.Persistences.Context.Configurations
{
   public class FavoritoConfiguration : IEntityTypeConfiguration<Favorito>
   {
      public void Configure(EntityTypeBuilder<Favorito> builder)
      {
         builder.HasKey(e => e.Id).HasName("PK__favorito__8D50056984CB6A72");

         builder.ToTable("favoritos", "mydb");
         
         builder.Property(e => e.Id).HasColumnName("idfavoritos").ValueGeneratedNever();

         builder.Property(e => e.Id).HasColumnName("idfavoritos");
         builder.Property(e => e.CandidatosFk).HasColumnName("CandidatosFK");
         builder.Property(e => e.OfertasEmpleosFk).HasColumnName("OfertasEmpleosFK");

         builder.HasOne(d => d.CandidatosFkNavigation).WithMany(p => p.Favoritos)
             .HasForeignKey(d => d.CandidatosFk)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_favoritos_candidatos");

         builder.HasOne(d => d.OfertasEmpleosFkNavigation).WithMany(p => p.Favoritos)
             .HasForeignKey(d => d.OfertasEmpleosFk)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_favoritos_oferta_empleo");

      }
   }
}
