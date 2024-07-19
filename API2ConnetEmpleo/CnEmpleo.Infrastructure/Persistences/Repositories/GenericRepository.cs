using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.API.Entities;
using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CnEmpleo.Infrastructure.Persistences.Repositories
{
   public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
   {
      private readonly EmpleosContext _context;
      private readonly DbSet<T> _dbSet;

      public GenericRepository(EmpleosContext context)
      {
         _context = context ?? throw new ArgumentNullException(nameof(context));
         _dbSet = _context.Set<T>() ?? throw new ArgumentNullException(nameof(_dbSet));
      }

      public async Task<IEnumerable<T>> GetAllAsync(
         Func<IQueryable<T>, IQueryable<T>> include = null)
      {
         IQueryable<T> query = _dbSet.AsNoTracking();

         if (include != null)
         {
            query = include(query);
         }

         return await query.ToListAsync();
      }



      public async Task<T> GetByIdAsync(int id)
      {
         var getById = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
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
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
         }
         return false;
      }

      
   }
}

