using ConnetEmpleo.Aplication.Dtos.Request;
using FluentValidation;

namespace ConnetEmpleo.Aplication.Validators
{
   public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
   {
      public LoginRequestDtoValidator()
      {
         RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("El email es requerido")
            .EmailAddress()
            .WithMessage("Ingresa un email válido");

         RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("La contraseña es requerida");

      }
   }
}
