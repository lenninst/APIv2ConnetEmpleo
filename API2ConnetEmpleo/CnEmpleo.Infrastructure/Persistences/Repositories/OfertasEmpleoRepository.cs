using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.API.Entities;
using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CnEmpleo.Infrastructure.Persistences.Repositories
{
   public class OfertasEmpleoRepository : GenericRepository<OfertasEmpleo>,  IOfertasEmpleoRepository
   {
      private readonly EmpleosContext _context;
      public OfertasEmpleoRepository(EmpleosContext context) : base(context)
        {
         _context = context;
            
        }

      public async Task<bool> AddOfertaEmpleo(OfertasEmpleo ofertasEmpleo)
      {
         if (ofertasEmpleo == null)
            throw new ArgumentException(nameof(ofertasEmpleo));
         return await RegisterAsync(ofertasEmpleo);
      }

      public async Task<List<OfertasEmpleo>> GetAllAsyncWithEmpresa()
      {
         return await _context.OfertasEmpleos
             .Include(o => o.EmpresaFkNavigation) // Asegúrate de incluir la empresa
             .ToListAsync();
      }


   }
}
