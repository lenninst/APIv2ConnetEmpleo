using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Interfaces
{
   public interface IOfertasEmpleoRepository : IGenericRepository<OfertasEmpleo>
   {
      Task<bool> AddOfertaEmpleo(OfertasEmpleo ofertasEmpleo);
      Task<List<OfertasEmpleo>> GetAllAsyncWithEmpresa();

   }
}
