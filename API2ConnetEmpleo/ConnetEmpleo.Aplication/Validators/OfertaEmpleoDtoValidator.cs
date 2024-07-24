using ConnetEmpleo.Aplication.Dtos.Request;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Text.RegularExpressions;

namespace ConnetEmpleo.Aplication.Validators
{
   public class OfertaEmpleoDtoValidator : AbstractValidator<OfertaEmpleoRequestDto>
   {

      public OfertaEmpleoDtoValidator ()
      {
         RuleFor (OfertaEmpleoRequestDto => OfertaEmpleoRequestDto.Titulo)
            .NotEmpty ()
            .WithMessage ("El campo Titulo es requerido");
         RuleFor(OfertaEmpleoRequestDto => OfertaEmpleoRequestDto.Descripcion)
            .NotEmpty()
            .WithMessage("El campo Descripcion es requerido");
         RuleFor(OfertaEmpleoRequestDto => OfertaEmpleoRequestDto.Fechapublicacion) 
            .NotEmpty()
           .WithMessage("El campo FechaPublicacion es requerido")
           .Must(BeValidDateFormat)
           .WithMessage("El formato de la fecha debe ser yyyy-MM-dd.");

         RuleFor(OfertaEmpleoRequestDto => OfertaEmpleoRequestDto.Aniosexperiencia)
            .NotEmpty()
            .WithMessage("El campo FechaCierre es requerido")
            .GreaterThan(0)
            .WithMessage("La experiencia debe ser un valor positivo");

         RuleFor(OfertaEmpleoRequestDto => OfertaEmpleoRequestDto.Modalidad)
            .NotEmpty()
            .WithMessage("El campo Modalidad es requerido")
            .Must(modalidad => modalidad == "Presencial" || modalidad == "Virtual" || modalidad =="Híbrido")
            .WithMessage("Modalidad debe ser 'Presencial', 'Virtual' o 'Híbrido'");

         RuleFor(OfertaEmpleoRequestDto => OfertaEmpleoRequestDto.Vacantes)
            .NotEmpty()
            .WithMessage("El campo Vacantes es requerido")
            .GreaterThan(0)
            .WithMessage("Las vacantes deben ser un valor positivo");

         RuleFor(OfertaEmpleoRequestDto => OfertaEmpleoRequestDto.Salario)
            .NotEmpty()
            .WithMessage("El campo Vacantes es requerido")
            .GreaterThan(0)
            .WithMessage("Las vacantes deben ser un valor positivo");
      }

      private bool BeValidDateFormat(string fechaPlublicacion)
      {
         var regex = @"^\d{4}-\d{2}-\d{2}$";
         return Regex.IsMatch(fechaPlublicacion, regex);
      }
   }
}
