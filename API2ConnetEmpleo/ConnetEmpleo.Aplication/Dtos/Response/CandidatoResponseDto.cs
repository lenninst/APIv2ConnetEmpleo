namespace ConnetEmpleo.Aplication.Dtos.Response
{
   public class CandidatoResponseDto
   {
      public int Id { get; set; } 
      public string? Nombre { get; set; }
      public string? Apellido { get; set; }
      public string? Nacionalidad { get; set; }
      public DateOnly? FechaNacimiento { get; set; }
      public string? Genero { get; set; }
      public long? DocumentoId { get; set; }
      public long? NumeroContacto { get; set; }
      public string? LugarDeResidencia { get; set; }
      public int? UserFk { get; set; }
      public string? RutasHv { get; set; }
      public IEnumerable<ExperienciaLaboralResponseDto> ExperienciaLaboral { get; set; } = new List<ExperienciaLaboralResponseDto>();
      public IEnumerable<FavoritoResponseDto> Favoritos { get; set; } = new List<FavoritoResponseDto>();
      public IEnumerable<FormacionAcademicaResponseDto> FormacionAcademicas { get; set; } = new List<FormacionAcademicaResponseDto>();
      public IEnumerable<PostulacionResponseDto> Postulaciones { get; set; } = new List<PostulacionResponseDto>();

   }
}
