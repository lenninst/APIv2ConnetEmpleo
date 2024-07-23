using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Interfaces
{
   public interface IFormacionAcademicaRepository : IGenericRepository<FormacionAcademica>
   {
      Task<bool> AddFormacionAcademica (FormacionAcademica formacionAcademica);
   }
}
