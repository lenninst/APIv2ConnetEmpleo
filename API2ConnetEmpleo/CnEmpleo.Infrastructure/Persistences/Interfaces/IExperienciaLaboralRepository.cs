﻿using ConnectEmpleo.Domain.Entities;

namespace CnEmpleo.Infrastructure.Persistences.Interfaces
{
   public interface IExperienciaLaboralRepository : IGenericRepository<ExperienciaLaboral>
   {
      Task<IEnumerable<ExperienciaLaboral>> GetExperienciaLaboral(int candidatoId);

      Task<bool> AddExperienciaLaboral(ExperienciaLaboral experienciaLaboral);


   }
}
