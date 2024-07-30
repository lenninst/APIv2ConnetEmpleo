using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Interfaces
{
   public interface IUserRepository : IGenericRepository<User>
   {
<<<<<<< HEAD
   }
=======
      Task<int> RegisterReturnidAsync(User user);
      }
>>>>>>> 6a3194b (feat: agredado user register controller)
}
