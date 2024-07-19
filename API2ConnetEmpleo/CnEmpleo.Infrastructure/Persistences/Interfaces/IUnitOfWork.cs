using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnEmpleo.Infrastructure.Persistences.Interfaces
{
   public interface IUnitOfWork : IDisposable
   {
      ICandidatoRepository CandidatoRepository { get; }
      IEmpresaRepository EmpresaRepository { get; }
      IExperienciaLaboralRepository ExperienciaLaboralRepository { get; }
      IFavoritoRepository FavoritoRepository { get; }
      IFormacionAcademicaRepository FormacionAcademicaRepository { get; }
      IOfertasEmpleoRepository OfertasEmpleoRepository { get; }
      IPostulacionRepository PostulacionRepository { get; }
      IUserRepository UserRepository { get; }

      void SaveChanges();
      Task SaveChangesAsync();

   }
}
