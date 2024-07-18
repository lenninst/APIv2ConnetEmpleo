using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.API.Entities;
using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CnEmpleo.Infrastructure.Persistences.Repositories
{
   public class CandidatoRepository : GenericRepository<Candidato>, ICandidatoRepository
   {
      private readonly EmpleosContext _context;
      public CandidatoRepository(EmpleosContext context) : base(context)
      {
         _context = context;
      }
      }
}

