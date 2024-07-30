using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.API.Entities;
using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Repositories
{
   public class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository
      
   {
      private readonly EmpleosContext _context;
      public EmpresaRepository(EmpleosContext context) : base(context)
      {
         _context = context;
      }
   }
}
