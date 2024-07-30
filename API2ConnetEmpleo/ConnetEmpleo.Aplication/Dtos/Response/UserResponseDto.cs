namespace ConnetEmpleo.Aplication.Dtos.Response
{
   public class UserResponseDto
   {
      public string? Username { get; set; }
      public string? Email { get; set; }
      public string UserType { get; set; } = null!;

      // Información simplificada de los Candidatos asociados
      public IEnumerable<CandidatoResponseDto> Candidatos { get; set; } = new List<CandidatoResponseDto>();

      // Información simplificada de las Empresas asociadas
      public IEnumerable<EmpresaResponseDto> Empresas { get; set; } = new List<EmpresaResponseDto>();

   }
}
