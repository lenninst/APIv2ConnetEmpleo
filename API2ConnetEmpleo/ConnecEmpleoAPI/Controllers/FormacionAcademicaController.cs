using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConnectEmpleo.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class FormacionAcademicaController : Controller
   {
      private readonly IFormacionAcademicaAplication _formacionAcademicaAplication;

      public FormacionAcademicaController(IFormacionAcademicaAplication formacionAcademicaAplication)
      {
         _formacionAcademicaAplication = formacionAcademicaAplication;

      }

      [HttpPost("{candidatoId:int}")]
      public async Task<ActionResult>AddFormacionAcademica(
         int candidatoId,
         [FromBody] FormacionAcademicaRequestDto formacionAcademicaRequestDto)
      {
         var response = await _formacionAcademicaAplication
            .AddFormacionAcademicaWithCandidatoId(candidatoId, formacionAcademicaRequestDto);
         return Ok(response);
      }

   }
}
