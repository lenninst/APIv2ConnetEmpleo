
using System.ComponentModel.DataAnnotations;

namespace ConnectEmpleo.Domain.Entities
{
   public abstract class  BaseEntity
   {
      [Key]
      public int Id { get; set; }

   }
}
