using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnEmpleo.Infrastructure.Persistences.Context.Configurations
{
   public class UserConfiguration : IEntityTypeConfiguration<User>
   {
      public void Configure (EntityTypeBuilder<User> builder)
      {
         builder.HasKey(e => e.Id).HasName("PK__users__F6101F0813F69CF7");

         builder.ToTable("users", "mydb");

         builder.Property(e => e.Id)
            .HasColumnName("idusers")
            .ValueGeneratedOnAdd(); 

         builder.Property(e => e.Id).HasColumnName("idusers");
         builder.Property(e => e.Email)
             .HasMaxLength(45)
             .HasColumnName("email");
         builder.Property(e => e.Password)
             .HasMaxLength(45)
             .HasColumnName("password");
         builder.Property(e => e.UserType)
             .HasMaxLength(50)
             .HasDefaultValue("DESCONOCIDO")
             .HasColumnName("userType");
         builder.Property(e => e.Username)
             .HasMaxLength(45)
             .HasColumnName("username");
      }
   }
}
