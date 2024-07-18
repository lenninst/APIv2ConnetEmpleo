using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.API.Entities;
using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CnEmpleo.Infrastructure.Persistences.Repositories
{
   public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
   {
      private readonly EmpleosContext _context;
      private readonly DbSet<T> _entity;

      public GenericRepository(EmpleosContext context)
      {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _entity = _context.Set<T>() ?? throw new ArgumentNullException(nameof(_entity));
      }

      public async Task<IEnumerable<T>> GetAllAsync()
      {
         var allcontent = await _entity.AsNoTracking().ToListAsync();
         return allcontent;
      }

      public async Task<T> GetByIdAsync(int id)
      {
         var getById = await _entity.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
         return getById!;
      }

      public async Task<bool> RegisterAsync(T entity)
      {
         await _context.AddAsync(entity);
         var recordsAffected = await _context.SaveChangesAsync();
         return recordsAffected > 0;
      }

      public async Task<bool> EditAsync(T entity)
      {
         _context.Update(entity);
         _context.Entry(entity).Property(x => x.Id).IsModified = false;
         var recordsAffected = await _context.SaveChangesAsync();
         return recordsAffected > 0;
      }

      public async Task<bool> RemoveAndGetUpdateAsync(int id)
      {
         T entity = await GetByIdAsync(id);
         if (entity != null && id > 0)
         {
            _entity.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
         }
         return false;
      }
   }
}

