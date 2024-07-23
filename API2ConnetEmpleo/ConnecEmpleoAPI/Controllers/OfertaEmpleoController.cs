using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConnectEmpleo.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class OfertaEmpleoController : Controller
   {
      private readonly IOfertaEmpleoAplication _ofertaEmpleoAplication;

        public OfertaEmpleoController(IOfertaEmpleoAplication ofertaEmpleoAplication)
        {
         _ofertaEmpleoAplication = ofertaEmpleoAplication;
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
    }
}
