
using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Interfaces
{
   public interface IGenericRepository<T> where T : BaseEntity
   {
      Task<T> GetByIdAsync(int id);
      Task<bool> RegisterAsync(T entity);
      Task<bool> EditAsync(T entity);
      Task<bool> RemoveAndGetUpdateAsync(int id);
      Task<IEnumerable<T>> GetAllAsync();
   }
}
