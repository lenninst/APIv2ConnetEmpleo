using AutoMapper;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConnectEmpleo.API.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
   public class CandidatoController : ControllerBase
   {
      private readonly ICandidatoAplication _candidatoAplication;
      public CandidatoController(ICandidatoAplication candidatoAplication, IMapper mapper)
      {
         _candidatoAplication = candidatoAplication;
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> CandidatoById(int id)
      {
         var response = await _candidatoAplication.GetCandidatoById(id);
         return Ok(response);
      }

      [HttpGet("candidato")]
      public async Task<IActionResult> GetAllCandidatos()
      {
         var response = await _candidatoAplication.GetAllCandidatos();
         return Ok(response);
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> UpdateCandidato(int id, [FromBody] CandidatoRequestDto candidatoRequestDto)
      {
         var response  = await _candidatoAplication.UpdateCandidato(id, candidatoRequestDto);
         return Ok(response);
      }


      [HttpGet("candidato/detalles")]
      public async Task<IActionResult> GetAllDetailsCandidatos()
      {
         var response = await _candidatoAplication.GetAllCandidatos();

         if (response.IsSuccess)
         {
            return Ok(response);
         }
         else
         {
            return BadRequest(response.Message);
         }
      }

   }
}
