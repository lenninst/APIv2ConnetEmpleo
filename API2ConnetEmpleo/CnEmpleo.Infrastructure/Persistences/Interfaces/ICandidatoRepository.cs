using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Interfaces
{
   public interface ICandidatoRepository : IGenericRepository<Candidato>
   {
      Task<Candidato> UpdateAndGetAsync(Candidato candidato);
   }
}
