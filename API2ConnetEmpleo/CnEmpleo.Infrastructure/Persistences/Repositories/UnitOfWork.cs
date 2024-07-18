using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.API.Entities;
using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Repositories
{
   public class UnitOfWork : IUnitOfWork
   {
      private readonly EmpleosContext _context;
      private Dictionary<Type, object> _repositories;
      public UnitOfWork(EmpleosContext context)
      {
         _context = context;
      }

      private TRepository GetRepository<TRepository, TEntity>()
         where TRepository : IGenericRepository<TEntity>
         where TEntity : BaseEntity
      {
         var type = typeof(TRepository);

         if(!_repositories.ContainsKey(type))
         {
            var repositoryInstance = Activator.CreateInstance(typeof(TRepository), _context);
            _repositories[type] = repositoryInstance;
         }
         
         return (TRepository)_repositories[type];

      }

      public ICandidatoRepository CandidatoRepository 
         => GetRepository<ICandidatoRepository, Candidato>();
      public IEmpresaRepository EmpresaRepository 
         => GetRepository<IEmpresaRepository, Empresa>();
      
      public IExperienciaLaboralRepository ExperienciaLaboralRepository 
         => GetRepository<IExperienciaLaboralRepository, ExperienciaLaboral>();
      public IFavoritoRepository FavoritoRepository
         => GetRepository<IFavoritoRepository, Favorito>();
      public IFormacionAcademicaRepository FormacionAcademicaRepository
                  => GetRepository<IFormacionAcademicaRepository, FormacionAcademica>();
      public IOfertasEmpleoRepository OfertasEmpleo
          => GetRepository<IOfertasEmpleoRepository, OfertasEmpleo>();

      public IPostulacionRepository Postulacion
          => GetRepository<IPostulacionRepository, Postulacion>();

      public IUserRepository UserRepository
          => GetRepository<IUserRepository, User>();


      public void SaveChange()
      {
         _context.SaveChanges();
      }

      public async Task SaveChangeAsync()
      {
         await _context.SaveChangesAsync();
      }

      public void Dispose()
      {
         _context.Dispose();
      }

   }
}
