using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.API.Entities;
using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CnEmpleo.Infrastructure.Persistences.Repositories
{
   public class ExperienciaLaboralRepository
      : GenericRepository<ExperienciaLaboral>, IExperienciaLaboralRepository
   {
      private readonly EmpleosContext _context;
      public ExperienciaLaboralRepository(EmpleosContext context) : base(context)
      {
         _context = context;
      }
      public async Task<IEnumerable<ExperienciaLaboral>> ObtenerExperienciasPorCandidatoIdAsync(int candidatoId)
      {
         return await _context.ExperienciaLaborals
         .Where(e => e.CandidatosFk == candidatoId)
         .ToListAsync();
      }

   }
}
