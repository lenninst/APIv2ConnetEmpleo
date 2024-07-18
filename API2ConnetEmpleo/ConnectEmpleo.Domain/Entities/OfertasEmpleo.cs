namespace ConnectEmpleo.Domain.Entities;

public partial class OfertasEmpleo : BaseEntity
{

   public string? Titulo { get; set; }

   public string? Descripcion { get; set; }

   public decimal? Salario { get; set; }

   public string? Ubicacion { get; set; }

   public DateOnly? Fechapublicacion { get; set; }

   public int? Aniosexperiencia { get; set; }

   public string? Modalidad { get; set; }

   public int? Vacantes { get; set; }

   public int EmpresaFk { get; set; }

   public virtual Empresa EmpresaFkNavigation { get; set; } = null!;

   public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

   public virtual ICollection<Postulacion> Postulaciones { get; set; } = new List<Postulacion>();
}
