using ConnetEmpleo.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConnectEmpleo.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class CandidatoController : Controller
   {
      private readonly ICandidatoAplication _candidatoAplication;
      public CandidatoController(ICandidatoAplication candidatoAplication)
      {
         _candidatoAplication = candidatoAplication;
      }

      [HttpGet("{candidatoId:int}")]
      public async Task<IActionResult> CandidatoById(int candidatoId)
      {
         var response = await _candidatoAplication.GetCandidatoById(candidatoId);
         return Ok(response);
      }

      [HttpGet("candidato")]
      public async Task<IActionResult> GetAllCandidatos()
      {
         var response = await _candidatoAplication.GetAllCandidatos();

         if(response.IsSuccess)
         {
            return Ok(response.Data);
         }
         else
         {
            return BadRequest(response.Message);
         }
      }

    }
}
