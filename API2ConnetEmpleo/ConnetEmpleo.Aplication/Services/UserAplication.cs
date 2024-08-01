using AutoMapper;
using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Extensions.Shared;
using ConnetEmpleo.Aplication.Interface;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;

namespace ConnetEmpleo.Aplication.Services
{
   internal class UserAplication : IUserAplication
   {
      private readonly IMapper _mapper;
      private readonly IUserRepository _userRepository;
      private readonly IValidator<UserRequestDto> _validator;
      private readonly IValidator<LoginRequestDto> _validatorLogin;
      private readonly ICandidatoRepository _candidatoRepository;
      private readonly JwtSettings _jwtSettings;


      public UserAplication(
         IMapper mapper,
         IUserRepository userRepository,
         IValidator<UserRequestDto> validator,
         IValidator<LoginRequestDto> validatorLogin,
         ICandidatoRepository candidatoRepository,
         IOptions<JwtSettings> jwtSettings
         )
      {
         _mapper = mapper;
         _userRepository = userRepository;
         _validator = validator;
         _validatorLogin = validatorLogin;
         _candidatoRepository = candidatoRepository;
         _jwtSettings = jwtSettings.Value;
      }

      public async Task<BaseResponse<bool>> AddUserAsync(UserRequestDto userRequestDto)
      {
         var response = new BaseResponse<bool>();

         try
         {
            var validationResult = _validator.Validate(userRequestDto);
            if (!validationResult.IsValid)
            {
               response.IsSuccess = false;
               response.Message = "Los datos del usuario no son válidos.";
               response.Errors = validationResult.Errors;
               return response;
            }

            var user = _mapper.Map<User>(userRequestDto);
            var userId = await _userRepository.RegisterReturnidAsync(user);

            if (userId > 0)
            {
               if (userRequestDto.UserType == "CANDIDATO")
               {
                  var candidato = new Candidato
                  {
                     UserFk = userId
                  };
                  var isCandidatoAdded = await _candidatoRepository.RegisterAsync(candidato);
                  if (isCandidatoAdded)
                  {
                     response.IsSuccess = true;
                     response.Message = "Usuario candidato registrado exitosamente";
                  }
                  else
                  {
                     response.IsSuccess = false;
                     response.Message = "Error al registrar el usuario";
                  }
               }
            }

         }
         catch (Exception e)
         {
            response.IsSuccess = false;
            response.Message = $"Error al registrar el usuario: {e.Message}";
         }
         return response;

      }

      public async Task<BaseResponse<bool>> LoginAsync(LoginRequestDto loginRequestDto)
      {
         var response = new BaseResponse<bool>();

         try
         {
            var validationResult = _validatorLogin.Validate(loginRequestDto);
            if (!validationResult.IsValid)
            {
               response.IsSuccess = false;
               response.Message = "Los datos del usuario no son válidos.";
               response.Errors = validationResult.Errors;
               return response;
            }

            var user = await _userRepository.GetUserByEmailAsync(loginRequestDto.Email);
            if (user == null)
            {
               response.IsSuccess = false;
               response.Message = "Usuario no encontrado";
               return response;
            }

            if (user.Password != loginRequestDto.Password)
            {
               response.IsSuccess = false;
               response.Message = "Contraseña incorrecta";
               return response;
            }

            var token = TokenExtensions.GenerateJwtToken(_jwtSettings, user);

            response.IsSuccess = true;
            response.Message = "Usuario autenticado correctamente";
            response.Token = token;

         }
         catch (Exception e)
         {
            response.IsSuccess = false;
            response.Message = $"Error al autenticar el usuario: {e.Message}";

         }
         return response;
      }  
   }
}
