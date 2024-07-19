using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CnEmpleo.Infrastructure.Helpers
{
   public static class QueryableHelper
   {
      public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
      {
         if (includes != null)
         {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
         }

         return query;
      }

      // Aquí puedes incluir otros métodos de ayuda, como el método de paginación comentado
      /* 
      public static IQueryable<T> Paginate<T>(this IQueryable<T> querable, BasePaginationRequest request)
      {
         return querable.Skip((request.numPage - 1) * request.Records).Take(request.Records);
      }
      */
   }
}
