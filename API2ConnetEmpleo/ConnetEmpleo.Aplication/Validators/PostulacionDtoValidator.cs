using ConnetEmpleo.Aplication.Dtos.Request;
using FluentValidation;

namespace ConnetEmpleo.Aplication.Validators
{
   public class PostulacionDtoValidator : AbstractValidator<PostulacionRequestDto>
   {

      public PostulacionDtoValidator()
      {
         RuleFor(PostulacionRequestDto => PostulacionRequestDto.CandidatosFk)
            .NotEmpty()
            .WithMessage("El campo CandidatosFk es requerido")
            .GreaterThan(0)
            .WithMessage("El candidato debe ser un valor positivo");

         RuleFor(PostulacionRequestDto => PostulacionRequestDto.OfertasEmpleosFk)
            .NotEmpty()
            .WithMessage("El campo CandidatosFk es requerido")
            .GreaterThan(0)
            .WithMessage("El candidato debe ser un valor positivo");

         RuleFor(PostulacionRequestDto => PostulacionRequestDto.EstadoPostulacion)
            .NotEmpty()
            .WithMessage("El campo CandidatosFk es requerido")
            .Must(estado => estado == "Activo" || estado == "Inactivo")
            .WithMessage("El estado debe ser 'Activo' o 'Inactivo'.");

      }
   }
}
