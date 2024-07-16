
namespace ConnectEmpleo.Domain.Entities;

public partial class FormacionAcademica : BaseEntity
{

   public string? Titulo { get; set; }

   public string? Institucion { get; set; }

   public string? Pais { get; set; }

   public string? FechaInicio { get; set; }

   public string? FechaFin { get; set; }

   public int CandidatosFk { get; set; }

   public virtual Candidato CandidatosFkNavigation { get; set; } = null!;
}
