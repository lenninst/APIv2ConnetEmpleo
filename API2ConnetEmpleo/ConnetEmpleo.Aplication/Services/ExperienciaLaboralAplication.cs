using AutoMapper;
using CnEmpleo.Infrastructure.Persistences.Interfaces;
using CnEmpleo.Infrastructure.Persistences.Repositories;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Interface;

namespace ConnetEmpleo.Aplication.Services
{
   internal class ExperienciaLaboralAplication : IExperienciaLaboralAplication
   {
      private readonly ICandidatoRepository _candidatoRepository;
      private readonly IExperienciaLaboralRepository _experienciaLaboralRepository;
      private readonly IMapper _mapper;

        public ExperienciaLaboralAplication(
           ICandidatoRepository candidatoRepository,
           IMapper mapper,
           IExperienciaLaboralRepository experienciaLaboralRepository
           )
        {
         _candidatoRepository = candidatoRepository;
         _mapper = mapper;
         _experienciaLaboralRepository = experienciaLaboralRepository;
        }

      public async Task<BaseResponse<bool>> AddExperienciaLaboralWithCandidatoId(int id, ExperienciaLaboralRequestDto experienciaLaboralRequestDto)
      {
         var response = new BaseResponse<bool>();

         try
         {
            // Verificar si el candidato está registrado
            var candidato = await _candidatoRepository.GetByIdAsync(id);
            if (candidato == null)
            {
               response.IsSuccess = false;
               response.Message = "Candidato no registrado";
               return response;
            }

            // Mapear el DTO a la entidad
            var experienciaLaboral = _mapper.Map<ExperienciaLaboral>(experienciaLaboralRequestDto);
            experienciaLaboral.CandidatosFk = id;  // Establecer el FK del candidato en la entidad

            // Registrar la experiencia laboral usando el método específico del repositorio
            var isAdded = await _experienciaLaboralRepository.AddExperienciaLaboral(experienciaLaboral);

            if (isAdded)
            {
               response.IsSuccess = true;
               response.Message = "Experiencia laboral registrada exitosamente";
            }
            else
            {
               response.IsSuccess = false;
               response.Message = "Error al registrar la experiencia laboral";
            }
         }
         catch (Exception ex)
         {
            response.IsSuccess = false;
            response.Message = $"Error al procesar la solicitud: {ex.Message}";
         }

         return response;
      }
   }
}
