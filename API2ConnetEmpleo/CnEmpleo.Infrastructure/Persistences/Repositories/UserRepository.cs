using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.API.Entities;
using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Repositories
{
   public class UserRepository : GenericRepository<User>, IUserRepository
   {
      private readonly EmpleosContext _context;
      public UserRepository(EmpleosContext context) : base(context)
      {
         _context = context;
      }

      public async Task<int> RegisterReturnidAsync(User entity)
      {
         _context.Users.Add(entity);
         await _context.SaveChangesAsync();
         return entity.Id;
      }




   }
}
