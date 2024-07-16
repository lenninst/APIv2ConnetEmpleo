using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnEmpleo.Infrastructure.Persistences.Context.Configurations
{
   public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
   {
      public void Configure(EntityTypeBuilder<Empresa> builder)
      {
         builder.HasKey(e => e.Id).HasName("PK__empresas__2A8C53D73940ACF1");

         builder.ToTable("empresas", "mydb");

         builder.Property(e => e.Id).HasColumnName("idempresas");
         builder.Property(e => e.Cantidadempleados).HasColumnName("cantidadempleados");
         builder.Property(e => e.Descripcion)
             .HasMaxLength(200)
             .HasColumnName("descripcion");
         builder.Property(e => e.Fechafundacion).HasColumnName("fechafundacion");
         builder.Property(e => e.Logo)
             .HasMaxLength(2083)
             .HasColumnName("logo");
         builder.Property(e => e.Nombre)
             .HasMaxLength(45)
             .HasColumnName("nombre");
         builder.Property(e => e.Sitioweb)
             .HasMaxLength(2083)
             .HasColumnName("sitioweb");
         builder.Property(e => e.Tipo)
             .HasMaxLength(45)
             .HasColumnName("tipo");
         builder.Property(e => e.UserFk).HasColumnName("UserFK");

         builder.HasOne(d => d.UserFkNavigation).WithMany(p => p.Empresas)
             .HasForeignKey(d => d.UserFk)
             .HasConstraintName("FK__empresas__user");


      }
   }
}
