namespace ConnectEmpleo.Domain.Entities;

public partial class User :BaseEntity
{

   public string? Username { get; set; }

   public string? Password { get; set; }

   public string? Email { get; set; }

   public string UserType { get; set; } = null!;

   public virtual ICollection<Candidato> Candidatos { get; set; } = new List<Candidato>();

   public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
