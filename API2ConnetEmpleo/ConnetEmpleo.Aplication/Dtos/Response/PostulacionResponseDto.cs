using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnetEmpleo.Aplication.Dtos.Response
{
   public class PostulacionResponseDto
   {

      public int CandidatosFk { get; set; }
      public int OfertasEmpleosFk { get; set; }
      public string EstadoPostulacion { get; set; } = null!;

      // Información simplificada del Candidato asociado
      public CandidatoResponseDto Candidato { get; set; } = new CandidatoResponseDto();

      // Información simplificada de la Oferta de Empleo asociada
      public OfertasEmpleoResponseDto OfertaEmpleo { get; set; } = new OfertasEmpleoResponseDto();

   }
}
