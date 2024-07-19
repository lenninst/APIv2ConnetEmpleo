using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnEmpleo.Infrastructure.Persistences.Context.Configurations
{
   public class OfertaEmpleoConfiguration : IEntityTypeConfiguration<OfertasEmpleo>
   {
      public void Configure(EntityTypeBuilder <OfertasEmpleo> builder)
      {
         builder.HasKey(e => e.Id).HasName("PK__ofertasE__F4B53090209A75AF");

         builder.ToTable("ofertasEmpleos", "mydb");

         builder.Property(e => e.Id).HasColumnName("IdOfertasEmpleos").ValueGeneratedNever();

         builder.Property(e => e.Aniosexperiencia).HasColumnName("aniosexperiencia");
         builder.Property(e => e.Descripcion)
             .HasMaxLength(600)
             .HasColumnName("descripcion");
         builder.Property(e => e.EmpresaFk).HasColumnName("EmpresaFK");
         builder.Property(e => e.Fechapublicacion).HasColumnName("fechapublicacion");
         builder.Property(e => e.Modalidad)
             .HasMaxLength(45)
             .HasColumnName("modalidad");
         builder.Property(e => e.Salario)
             .HasColumnType("decimal(18, 2)")
             .HasColumnName("salario");
         builder.Property(e => e.Titulo)
             .HasMaxLength(200)
             .HasColumnName("titulo");
         builder.Property(e => e.Ubicacion)
             .HasMaxLength(200)
             .HasColumnName("ubicacion");
         builder.Property(e => e.Vacantes).HasColumnName("vacantes");

         builder.HasOne(d => d.EmpresaFkNavigation).WithMany(p => p.OfertasEmpleos)
             .HasForeignKey(d => d.EmpresaFk)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK__ofertasEm__empre__44FF419A");
      }
   }
}
