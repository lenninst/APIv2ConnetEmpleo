using AutoMapper;
using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Response;
using ConnetEmpleo.Aplication.Interface;

namespace ConnetEmpleo.Aplication.Services
{
   internal class CandidatoAplication : ICandidatoAplication
   {
      private readonly ICandidatoRepository _candidatoRepository;
      private readonly IMapper _mapper;
      public CandidatoAplication (ICandidatoRepository candidatoRepository, IMapper mapper)
      {
         _candidatoRepository = candidatoRepository;
         _mapper = mapper;
      }

      public async Task<BaseResponse<IEnumerable<CandidatoResponseDto>>> GetAllCandidatos()
      {
         var response = new BaseResponse<IEnumerable<CandidatoResponseDto>>();

         try
         {
            var candidatos = await _candidatoRepository.GetAllAsync();
            var candidatoDtos = _mapper.Map<IEnumerable<CandidatoResponseDto>>(candidatos);

            response.Data = candidatoDtos;
            response.IsSuccess = true;
            response.Message = "Candidatos obtenidos exitosamente";
         }
         catch (Exception ex)
         {
            response.IsSuccess = false;
            response.Message = $"Error al obtener candidatos: {ex.Message}";
         }

         return response;
      }

      public async Task<BaseResponse<CandidatoResponseDto>> GetCandidatoById(int id)
      {
         var response = new BaseResponse<CandidatoResponseDto>();

         try
         {
            var candidato = await _candidatoRepository.GetByIdAsync(id);

            if(candidato == null)
            {
               response.IsSuccess = false;
               response.Message = "Candidato no encontrado";
            }
            response.Data = _mapper.Map<CandidatoResponseDto>(candidato);
            response.IsSuccess = true;
            response.Message = "Candidato encontrado exitosamente";


         }
         catch (Exception ex)
         {
            response.IsSuccess = false;
            response.Message = $"Error el obtener candidato: {ex.Message}";
         }
         return response;

      }
   }
}
