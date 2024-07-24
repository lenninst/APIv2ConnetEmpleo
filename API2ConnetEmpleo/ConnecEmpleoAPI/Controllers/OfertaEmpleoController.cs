using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ConnectEmpleo.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class OfertaEmpleoController : Controller
   {
      private readonly IOfertaEmpleoAplication _ofertaEmpleoAplication;
      private readonly IPostulacionAplication _postulacionAplication;

        public OfertaEmpleoController(IOfertaEmpleoAplication ofertaEmpleoAplication, IPostulacionAplication postulacionAplication)
      {
         _ofertaEmpleoAplication = ofertaEmpleoAplication;
         _postulacionAplication = postulacionAplication;
      }

      [HttpPost("{empresaId:int}")]
      public async Task<ActionResult> AddOfertaEmpleo(
         int empresaId,
         [FromBody] OfertaEmpleoRequestDto ofertaEmpleoRequestDto
         )
      {
         try
         {
            var response = await _ofertaEmpleoAplication
         .AddOfertaEmpleoWhitEmpresaId(empresaId, ofertaEmpleoRequestDto);
            return Ok(response);
         }
         catch (Exception ex)
         {
            return BadRequest(new
            {
               isSuccess = false,
               message = $"Error al procesar solicitud: {ex.InnerException?.Message ?? ex.Message}",
               errors = ex.InnerException?.StackTrace
            });
         }
      }


      [HttpPost("Postular")]
      public async Task<ActionResult> Postular ( [FromBody] PostulacionRequestDto postulacionRequestDto)
      {
         try
         {
            var response = await _postulacionAplication
         .AddPostulacion(postulacionRequestDto);
            return Ok(response);
         }
         catch (Exception ex)
         {
            return BadRequest(new
            {
               isSuccess = false,
               message = $"Error al procesar solicitud: {ex.InnerException?.Message ?? ex.Message}",
               errors = ex.InnerException?.StackTrace
            });
         }
      }  

    }
}
