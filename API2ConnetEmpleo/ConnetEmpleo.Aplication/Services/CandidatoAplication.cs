using AutoMapper;
using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Dtos.Response;
using ConnetEmpleo.Aplication.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConnetEmpleo.Aplication.Services
{
   internal class CandidatoAplication : ICandidatoAplication
   {
      private readonly ICandidatoRepository _candidatoRepository;
      private readonly IMapper _mapper;
      private readonly IUnitOfWork _unitOfWork;
      public CandidatoAplication (
         ICandidatoRepository candidatoRepository,
         IMapper mapper,
         IUnitOfWork unitOfWork
         )
      {
         _candidatoRepository = candidatoRepository;

         _mapper = mapper;
         _unitOfWork = unitOfWork;
      }

      public async Task<BaseResponse<IEnumerable<CandidatoResponseDto>>> GetAllCandidatos()
      {
         var response = new BaseResponse<IEnumerable<CandidatoResponseDto>>();
      
         try
         {
            var candidatos = await _candidatoRepository.GetAllAsync(
            query => query.Include(c => c.ExperienciaLaborals)
                          .Include(c => c.Favoritos)
                          .Include(c => c.FormacionAcademicas)
                          .Include(c => c.Postulaciones)
        );

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

      public async Task<BaseResponse<CandidatoResponseDto>> UpdateCandidato(int id, CandidatoRequestDto updateDto)
      {
         var response = new BaseResponse<CandidatoResponseDto>();

         try
         {
            var candidato = await _candidatoRepository.GetByIdAsync(id);

            if (candidato == null)
            {
               response.IsSuccess = false;
               response.Message = "Candidato no encontrado";
               return response;
            }

            // Mapear los datos de updateDto a la entidad candidato
            _mapper.Map(updateDto, candidato);

            // Actualizar y obtener la entidad actualizada
            var updatedCandidato = await _candidatoRepository.UpdateAndGetAsync(candidato);

            response.Data = _mapper.Map<CandidatoResponseDto>(updatedCandidato);
            response.IsSuccess = true;
            response.Message = "Candidato actualizado exitosamente";
         }
         catch (Exception ex)
         {
            response.IsSuccess = false;
            response.Message = $"Error al actualizar candidato: {ex.Message}";
         }

         return response;
      }
    
   }
}
