namespace ConnetEmpleo.Aplication.Dtos.Response
{
   public class FormacionAcademicaResponseDto
   {
      public int Id { get; set; } 
      public string? Titulo { get; set; }
      public string? Institucion { get; set; }
      public string? Pais { get; set; }
      public string? FechaInicio { get; set; }
      public string? FechaFin { get; set; }
      public int CandidatosFk { get; set; }

   }
}
