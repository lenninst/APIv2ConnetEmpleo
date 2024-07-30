using ConnetEmpleo.Aplication.Dtos.Request;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ConnetEmpleo.Aplication.Validators
{
   public class UserResquestDtoValidator : AbstractValidator<UserRequestDto>
   {
      public UserResquestDtoValidator()
      {
         RuleFor(UserRequestDto => UserRequestDto.UserName)
            .NotEmpty()
            .WithMessage("El nombre de usuario es requerido");
         RuleFor(UserRequestDto => UserRequestDto.Email)
            .NotEmpty()
            .WithMessage("El campo de correo electrónico no puede estar vacío.")
            .EmailAddress()
            .WithMessage("El correo electrónico ingresado no es válido.");
         RuleFor(UserRequestDto => UserRequestDto.Password)
    .NotEmpty()
    .WithMessage("La contraseña no puede estar vacía.")
    .MinimumLength(8)
    .WithMessage("La contraseña debe tener al menos 8 caracteres.")
    .Matches("[A-Z]")
    .WithMessage("La contraseña debe contener al menos una letra mayúscula.")
    .Matches("[a-z]")
    .WithMessage("La contraseña debe contener al menos una letra minúscula.")
    .Matches("[0-9]")
    .WithMessage("La contraseña debe contener al menos un número.")
    .Matches("[^a-zA-Z0-9]")
    .WithMessage("La contraseña debe contener al menos un carácter especial.");

         RuleFor (UserRequestDto => UserRequestDto.UserType)
            .NotEmpty()
            .WithMessage("El tipo de usuario es requerido")
            .Must(userType => userType == "CANDIDATO" || userType == "EMPRESA")
            .WithMessage("El tipo de usuario debe ser 'CANDIDATO' o 'EMPRESA'");
      }

   }
}
