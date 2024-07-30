﻿using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.API.Entities;
using ConnectEmpleo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CnEmpleo.Infrastructure.Persistences.Repositories
{
<<<<<<< HEAD
   public class CandidatoRepository : GenericRepository<Candidato>, ICandidatoRepository
=======
   public class CandidatoRepository : GenericRepository<Candidato>,
      ICandidatoRepository
>>>>>>> 6a3194b (feat: agredado user register controller)
   {
      private readonly EmpleosContext _context;
      public CandidatoRepository(EmpleosContext context) : base(context)
      {
         _context = context;
      }

     public async Task<Candidato> UpdateAndGetAsync (Candidato candidato)
      {
         _context.Entry(candidato).State = EntityState.Modified;
         await _context.SaveChangesAsync();

         return await _context.Candidatos
            .Include(c => c.ExperienciaLaborals)
            .Include(c => c.Favoritos)
            .Include(c => c.FormacionAcademicas)
            .Include(c => c.Postulaciones)
            .FirstOrDefaultAsync(c => c.Id == candidato.Id);
      }



   }
}

