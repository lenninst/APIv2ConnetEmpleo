

namespace ConnectEmpleo.Domain.Entities;

public partial class Candidato : BaseEntity
{

   public string? Nombre { get; set; }

   public string? Apellido { get; set; }

   public string? Nacionalidad { get; set; }

   public DateOnly? Fechanacimiento { get; set; }

   public string? Genero { get; set; }

   public long? Documentoid { get; set; }

   public long? Numerocontacto { get; set; }

   public string? Lugarderesidencia { get; set; }

   public int? UserFk { get; set; }

   public string? RutasHv { get; set; }

   public virtual ICollection<ExperienciaLaboral> ExperienciaLaborals { get; set; } = new List<ExperienciaLaboral>();

   public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

   public virtual ICollection<FormacionAcademica> FormacionAcademicas { get; set; } = new List<FormacionAcademica>();

   public virtual ICollection<Postulacion> Postulaciones { get; set; } = new List<Postulacion>();

   public virtual User? UserFkNavigation { get; set; }
}
