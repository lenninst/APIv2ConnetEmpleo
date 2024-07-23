using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.API.Entities;
using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Repositories
{
   public class FormacionAcademicaRepository :
      GenericRepository<FormacionAcademica>, IFormacionAcademicaRepository
   {
      private readonly EmpleosContext _context;

      public FormacionAcademicaRepository(EmpleosContext context) : base (context)
      {
         _context = context;
      }

      public async Task<bool> AddFormacionAcademica(FormacionAcademica formacionAcademica)
      {
         if(formacionAcademica == null)
            throw new ArgumentException(nameof(formacionAcademica));
         return await RegisterAsync(formacionAcademica);
      }
   }
}
