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
      public async Task<IEnumerable<ExperienciaLaboral>> GetExperienciaLaboral(int candidatoId)
      {
         return await _context.ExperienciaLaborals
         .Where(e => e.CandidatosFk == candidatoId)
         .ToListAsync();
      }

      public async Task<bool> AddExperienciaLaboral(ExperienciaLaboral experienciaLaboral) 
      {
        if (experienciaLaboral == null)
            throw new ArgumentException(nameof(experienciaLaboral));
        return await RegisterAsync(experienciaLaboral);
      }

   }
}
