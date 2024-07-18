using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnetEmpleo.Aplication.Dtos.Response
{
   public class EmpresaResponseDto
   {
      public string? Nombre { get; set; }
      public string? Logo { get; set; }
      public string? Sitioweb { get; set; }
      public string? Tipo { get; set; }
      public string? Descripcion { get; set; }
      public int? Cantidadempleados { get; set; }
      public DateOnly? Fechafundacion { get; set; }
      public int? UserFk { get; set; }

      // Opcional: Si necesitas mostrar alguna información resumida sobre las ofertas de empleo asociadas
      public int OfertasEmpleosCount { get; set; }

      // Opcional: Si necesitas mostrar información sobre el usuario asociado de forma resumida
      public UserResponseDto? User { get; set; }
   }
}
