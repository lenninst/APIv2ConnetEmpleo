namespace ConnetEmpleo.Aplication.Dtos.Request
{
   public class CandidatoRequestDto
   {
      public string? Nombre { get; set; }
      public string? Apellido { get; set; }
      public string? Nacionalidad { get; set; }
      public DateOnly? FechaNacimiento { get; set; }
      public string? Genero { get; set; }
      public long? DocumentoId { get; set; }
      public long? NumeroContacto { get; set; }
      public string? LugarDeResidencia { get; set; }
      public string? RutasHv { get; set; }

   }
}
