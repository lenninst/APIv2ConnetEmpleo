using AutoMapper;
using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Dtos.Response;
using ConnetEmpleo.Aplication.Interface;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ConnetEmpleo.Aplication.Services
{
   internal class OfertaEmpleoAplication : IOfertaEmpleoAplication
   {
      private readonly IEmpresaRepository _empresaRepository;
      private readonly IMapper _mapper;
      private readonly IOfertasEmpleoRepository _ofertaEmpleoRepository;
      private readonly IValidator<OfertaEmpleoRequestDto> _validator;

        public OfertaEmpleoAplication(
           IEmpresaRepository empresaRepository, 
           IMapper mapper,
           IOfertasEmpleoRepository ofertaEmpleoRepository,
           IValidator<OfertaEmpleoRequestDto> validator
           )
        {
         _empresaRepository = empresaRepository;
         _mapper = mapper;
         _ofertaEmpleoRepository = ofertaEmpleoRepository;
         _validator = validator;
            
        }
      public async Task<BaseResponse<bool>> AddOfertaEmpleoWhitEmpresaId(int id, OfertaEmpleoRequestDto ofertaEmpleoRequestDto)
      {
         var response = new BaseResponse<bool>();
         try
         {
            // Verifica si la empresa existe
            var empresa = await _empresaRepository.GetByIdAsync(id);
            if (empresa == null)
            {
               response.IsSuccess = false;
               response.Message = "Empresa no registrada";
               return response;
            }
            
            //validar dto 
            var validationResult = await _validator.ValidateAsync(ofertaEmpleoRequestDto);
            if (!validationResult.IsValid)
            {
               response.IsSuccess = false;
               response.Message = "Datos de la oferta de empleo no válidos";
               response.Message = validationResult.Errors.First().ErrorMessage;
               return response;
            }

            // Mapear el DTO a la entidad
            var ofertaEmpleo = _mapper.Map<OfertasEmpleo>(ofertaEmpleoRequestDto);
            ofertaEmpleo.EmpresaFk = id;

            // Intenta agregar la oferta de empleo
            var isAdded = await _ofertaEmpleoRepository.AddOfertaEmpleo(ofertaEmpleo);
            if (isAdded)
            {
               response.IsSuccess = true;
               response.Message = "Oferta de empleo registrada exitosamente";
            }
            else
            {
               response.IsSuccess = false;
               response.Message = "Error al registrar la oferta de empleo.";
            }
         }
         catch (Exception ex)
         {
            response.IsSuccess = false;
            response.Message = $"Error al procesar solicitud: {ex.Message}";
         }

         return response;
      }


      public async Task<BaseResponse<List<OfertasEmpleoResponseDto>>> getOfertas()
      {
         var response = new BaseResponse<List<OfertasEmpleoResponseDto>>();
         try
         {
            var ofertas = await _ofertaEmpleoRepository.GetAllAsyncWithEmpresa();
            if (ofertas == null || !ofertas.Any())
            {
               response.IsSuccess = false;
               response.Message = "No hay ofertas de empleo registradas";
               return response;
            }

            var ofertasDto = _mapper.Map<List<OfertasEmpleoResponseDto>>(ofertas);
            response.Data = ofertasDto;
            response.IsSuccess = true;
            response.Message = "Ofertas de empleo obtenidas exitosamente";
         }
         catch (Exception ex)
         {
            response.IsSuccess = false;
            response.Message = $"Error al procesar solicitud: {ex.Message}";
         }

         return response;
      }



   }
}
