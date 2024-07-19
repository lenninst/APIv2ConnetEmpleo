using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConnectEmpleo.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ExperienciaLaboralController : Controller
   {
      private readonly IExperienciaLaboralRepository _experienciaLaboralRepository;
      public ExperienciaLaboralController (IExperienciaLaboralRepository experienciaLaboralRepository)
      {
         _experienciaLaboralRepository = experienciaLaboralRepository;
      }

      [HttpGet("{candidatoId:int}")]
      public async Task<ActionResult<IEnumerable<ExperienciaLaboral>>> GetExperienciaLaboralByCandidatoId(int candidatoId)
      {
         var experiencias = await _experienciaLaboralRepository.ObtenerExperienciasPorCandidatoIdAsync(candidatoId);
         if (experiencias == null || !experiencias.Any())
         {
            return NotFound();
         }
         return Ok(experiencias);

      }

   }
}
