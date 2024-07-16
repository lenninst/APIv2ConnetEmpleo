
namespace ConnectEmpleo.Domain.Entities;

public partial class Favorito : BaseEntity
{

   public int CandidatosFk { get; set; }

   public int OfertasEmpleosFk { get; set; }

   public virtual Candidato CandidatosFkNavigation { get; set; } = null!;

   public virtual OfertasEmpleo OfertasEmpleosFkNavigation { get; set; } = null!;
}
