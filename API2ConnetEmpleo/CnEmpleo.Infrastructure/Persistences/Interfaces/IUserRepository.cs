using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Interfaces
{
   public interface IUserRepository : IGenericRepository<User>
   {
      Task<int> RegisterReturnidAsync(User user);
      }
}
