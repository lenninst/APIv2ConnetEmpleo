
namespace ConnectEmpleo.Domain.Entities;

public partial class Empresa : BaseEntity
{

   public string? Nombre { get; set; }

   public string? Logo { get; set; }

   public string? Sitioweb { get; set; }

   public string? Tipo { get; set; }

   public string? Descripcion { get; set; }

   public int? Cantidadempleados { get; set; }

   public DateOnly? Fechafundacion { get; set; }

   public int? UserFk { get; set; }

   public virtual ICollection<OfertasEmpleo> OfertasEmpleos { get; set; } = new List<OfertasEmpleo>();

   public virtual User? UserFkNavigation { get; set; }
}
