using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConnectEmpleo.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ExperienciaLaboralController : Controller
   {
      private readonly IExperienciaLaboralRepository _experienciaLaboralRepository;
      private readonly IExperienciaLaboralAplication _experienciaLaboralAplication;
      public ExperienciaLaboralController (
         IExperienciaLaboralRepository experienciaLaboralRepository,
         IExperienciaLaboralAplication experienciaLaboralAplication)
      {
         _experienciaLaboralRepository = experienciaLaboralRepository;
         _experienciaLaboralAplication = experienciaLaboralAplication;
      }

      [HttpGet("{candidatoId:int}")]
      public async Task<ActionResult<IEnumerable<ExperienciaLaboral>>> GetExperienciaLaboralByCandidatoId(int candidatoId)
      {
         var experiencias = await _experienciaLaboralRepository.GetExperienciaLaboral(candidatoId);
         if (experiencias == null || !experiencias.Any())
         {
            return NotFound();
         }
         return Ok(experiencias);

      }

      [HttpPost("{candidatoId:int}")]
      public async Task<IActionResult> AddExperienciaLaboral(int candidatoId, 
         [FromBody] ExperienciaLaboralRequestDto experienciaLaboralRequestDto)
      {
         var response = await _experienciaLaboralAplication.AddExperienciaLaboralWithCandidatoId(candidatoId, experienciaLaboralRequestDto);
         return Ok(response);

      }

   }
}
