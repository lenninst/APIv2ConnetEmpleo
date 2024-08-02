namespace ConnetEmpleo.Aplication.Dtos.Response
{
   public class OfertasEmpleoResponseDto
   {
      public int Id { get; set; } 
      public string? Titulo { get; set; }
      public string? Descripcion { get; set; }
      public decimal? Salario { get; set; }
      public string? Ubicacion { get; set; }
      public string? Fechapublicacion { get; set; }
      public int? Aniosexperiencia { get; set; }
      public string? Modalidad { get; set; }
      public int? Vacantes { get; set; }
      public int EmpresaFk { get; set; }

      public EmpresaResponseDto Empresa { get; set; } = new EmpresaResponseDto();


   }
}
