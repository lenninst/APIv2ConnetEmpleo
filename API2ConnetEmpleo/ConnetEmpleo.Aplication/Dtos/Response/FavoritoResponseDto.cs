namespace ConnetEmpleo.Aplication.Dtos.Response
{
   public class FavoritoResponseDto
   {
      public int CandidatosFk { get; set; }
      public int OfertasEmpleosFk { get; set; }

      public OfertasEmpleoResponseDto OfertaEmpleo { get; set; } = new OfertasEmpleoResponseDto();

   }
}
