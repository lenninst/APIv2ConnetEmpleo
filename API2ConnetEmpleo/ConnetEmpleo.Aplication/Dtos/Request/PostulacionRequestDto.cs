using ConnectEmpleo.Domain.Entities;

namespace ConnetEmpleo.Aplication.Dtos.Request
{
   public class PostulacionRequestDto
   {

      public int CandidatosFk { get; set; }

      public int OfertasEmpleosFk { get; set; }

      public string EstadoPostulacion { get; set; } = null!;

   }
}
