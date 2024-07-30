using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnEmpleo.Infrastructure.Persistences.Context.Configurations
{
   public class CandidatoConfiguration : IEntityTypeConfiguration<Candidato>
   {
      public void Configure(EntityTypeBuilder<Candidato> builder)
      {
         builder.HasKey(e => e.Id).HasName("PK__candidat__23FC03854F8353CA");

         builder.ToTable("candidatos", "mydb");

<<<<<<< HEAD
         builder.Property(e => e.Id).HasColumnName("IdCandidatos").ValueGeneratedNever();

      builder.Property(e => e.Apellido)
=======
         builder.Property(e => e.Id).HasColumnName("IdCandidatos")
            .ValueGeneratedOnAdd();

         builder.Property(e => e.Apellido)
>>>>>>> 6a3194b (feat: agredado user register controller)
             .HasMaxLength(45)
             .HasColumnName("apellido");
         builder.Property(e => e.Documentoid).HasColumnName("documentoid");
         builder.Property(e => e.Fechanacimiento).HasColumnName("fechanacimiento");
         builder.Property(e => e.Genero)
             .HasMaxLength(45)
             .HasColumnName("genero");
         builder.Property(e => e.Lugarderesidencia)
             .HasMaxLength(45)
             .HasColumnName("lugarderesidencia");
         builder.Property(e => e.Nacionalidad)
             .HasMaxLength(45)
             .HasColumnName("nacionalidad");
         builder.Property(e => e.Nombre)
             .HasMaxLength(45)
             .HasColumnName("nombre");
         builder.Property(e => e.Numerocontacto).HasColumnName("numerocontacto");
         builder.Property(e => e.RutasHv)
             .HasMaxLength(255)
             .HasColumnName("RutasHV");
         builder.Property(e => e.UserFk).HasColumnName("UserFK");

         builder.HasOne(d => d.UserFkNavigation).WithMany(p => p.Candidatos)
             .HasForeignKey(d => d.UserFk)
             .HasConstraintName("FK__candidatos__user");

      }
   }
}
