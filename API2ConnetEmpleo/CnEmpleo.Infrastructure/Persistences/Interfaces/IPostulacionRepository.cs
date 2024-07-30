using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Interfaces
{
   public interface IPostulacionRepository :IGenericRepository<Postulacion>
   {
      Task<bool> AddPostulacion(Postulacion postulacion);
   }
}
