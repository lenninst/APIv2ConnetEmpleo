namespace ConnectEmpleo.Domain.Entities;

public partial class Postulacione : BaseEntity
{

   public int CandidatosFk { get; set; }

   public int OfertasEmpleosFk { get; set; }

   public string EstadoPostulacion { get; set; } = null!;

   public virtual Candidato CandidatosFkNavigation { get; set; } = null!;

   public virtual OfertasEmpleo OfertasEmpleosFkNavigation { get; set; } = null!;
}
