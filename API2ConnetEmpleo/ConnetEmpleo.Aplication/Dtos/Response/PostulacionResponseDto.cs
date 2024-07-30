namespace ConnetEmpleo.Aplication.Dtos.Response
{
   public class PostulacionResponseDto
   {

      public int CandidatosFk { get; set; }
      public int OfertasEmpleosFk { get; set; }
      public string EstadoPostulacion { get; set; } = null!;

      // Información simplificada de la Oferta de Empleo asociada
      public OfertasEmpleoResponseDto OfertaEmpleo { get; set; } = new OfertasEmpleoResponseDto();

   }
}
