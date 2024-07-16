
namespace ConnectEmpleo.Domain.Entities;

public partial class ExperienciaLaboral : BaseEntity 
{

   public string? Puesto { get; set; }

   public string? Establecimiento { get; set; }

   public int? AniosExperiencia { get; set; }

   public string? Descripcion { get; set; }

   public int CandidatosFk { get; set; }

   public virtual Candidato CandidatosFkNavigation { get; set; } = null!;
}
