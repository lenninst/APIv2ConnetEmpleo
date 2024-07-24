using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.API.Entities;
using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Repositories
{
   public class PostulacionRepository :
      GenericRepository<Postulacion>, IPostulacionRepository
   {
      private readonly EmpleosContext _context;
      public PostulacionRepository(EmpleosContext context) : base(context)
      {
         _context = context;
      }

      public async Task<bool> AddPostulacion(Postulacion postulacion)
      {
         if (postulacion == null)
            throw new ArgumentException(nameof(postulacion));
         return await RegisterAsync(postulacion);
      }
   }
}
