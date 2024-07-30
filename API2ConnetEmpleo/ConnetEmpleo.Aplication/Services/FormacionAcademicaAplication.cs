using AutoMapper;
using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Interface;

namespace ConnetEmpleo.Aplication.Services
{
   internal class FormacionAcademicaAplication : IFormacionAcademicaAplication
   {
      private readonly ICandidatoRepository _candidatoRepository;
      private readonly IFormacionAcademicaRepository _formacionAcademicaRepository;
      private readonly IMapper _mapper;

      public FormacionAcademicaAplication(
         ICandidatoRepository candidatoRepository,
         IFormacionAcademicaRepository formacionAcademicaRepository,
         IMapper mapper

           )
        {
         _candidatoRepository = candidatoRepository;
         _formacionAcademicaRepository = formacionAcademicaRepository;
         _mapper = mapper;
        }

      public async Task<BaseResponse<bool>> AddFormacionAcademicaWithCandidatoId(
         int id, FormacionAcademicaRequestDto formacionAcademicaRequestDto
         )
      {
         var response = new BaseResponse<bool>();

         try
         {
            var candidato = await _candidatoRepository.GetByIdAsync(id);
            if(candidato == null)
            {
               response.IsSuccess = false;
               response.Message = "Candidato no registrado";
               return response;
            }

            var formacionAcademica = _mapper.Map<FormacionAcademica>(formacionAcademicaRequestDto);
           formacionAcademica.CandidatosFk = id;

            var isAdded = await _formacionAcademicaRepository.AddFormacionAcademica(formacionAcademica);
            if(isAdded)
            {
               response.IsSuccess = true;
               response.Message = "Formación académica registrada exitosamente";
            }
            else
            {
               response.IsSuccess = false;
               response.Message = "Error al registrar la formación académica";
            }

            }
         catch(Exception ex)
         {
            response.IsSuccess = false;
            response.Message = $"Error al procesar solicitud: {ex.Message}";
         }

         return response;

        

      }


    }
}
