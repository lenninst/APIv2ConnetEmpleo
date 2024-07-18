using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnetEmpleo.Aplication.Dtos.Response
{
   public class FavoritoResponseDto
   {
      public int CandidatosFk { get; set; }
      public int OfertasEmpleosFk { get; set; }

      public OfertasEmpleoResponseDto OfertaEmpleo { get; set; } = new OfertasEmpleoResponseDto();

   }
}
