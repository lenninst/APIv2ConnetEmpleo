using AutoMapper;
using CnEmpleo.Infrastructure.Persistences.Interfaces;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Interface;
using FluentValidation;

namespace ConnetEmpleo.Aplication.Services
{
   internal class PostulacionAplication: IPostulacionAplication
   {
      private readonly IMapper _mapper;
      private readonly IPostulacionRepository _postulacionRepository;
      private readonly IValidator<PostulacionRequestDto> _validator;
      private readonly  ICandidatoRepository _candidatoRepository;
      private readonly IOfertasEmpleoRepository _ofertasEmpleosRepository;

      public PostulacionAplication( ICandidatoRepository candidatoRepository,
         IValidator<PostulacionRequestDto> validator,
         IPostulacionRepository postulacionRepository,
         IMapper mapper, 
         IOfertasEmpleoRepository ofertasEmpleosRepository
         )
      {
         _postulacionRepository = postulacionRepository;
         _mapper = mapper;
         _validator = validator;
         _candidatoRepository = candidatoRepository;
         _ofertasEmpleosRepository = ofertasEmpleosRepository;
      }


      public async Task<BaseResponse<bool>> AddPostulacion(PostulacionRequestDto postulacionRequestDto )
      {
         var candidatoId = postulacionRequestDto.CandidatosFk;
         var ofertaId = postulacionRequestDto.OfertasEmpleosFk;

         var response = new BaseResponse<bool>();

         try
         {
            var candidato = await _candidatoRepository.GetByIdAsync(candidatoId);
            if (candidato ==null)
            {
               response.IsSuccess = false;
               response.Message = "Candidato no registrado";
               return response;
            }

            var oferta = await _ofertasEmpleosRepository.GetByIdAsync(ofertaId);
            if (oferta == null)
            {
               response.IsSuccess = false;
               response.Message = "Oferta no registrada";
               return response;
            }

            // Validar el DTO
            var validationResult = await _validator.ValidateAsync(postulacionRequestDto);
            if (!validationResult.IsValid)
            {
               response.IsSuccess = false;
               response.Message = validationResult.Errors.First().ErrorMessage;
               return response;
            }

            // Mapear el DTO a la entidad
            var postulacion = _mapper.Map<Postulacion>(postulacionRequestDto);
           
            // Intenta agregar la postulacion
            var isAdded = await _postulacionRepository.AddPostulacion(postulacion);
            if (isAdded)
            {
               response.IsSuccess = true;
               response.Message = "Postulacion registrada exitosamente";
            }
            else
            {
               response.IsSuccess = false;
               response.Message = "Error al registrar la postulacion.";
            }
         }
         catch (Exception ex)
         {
            response.IsSuccess = false;
            response.Message = ex.Message;
         }

         return response;


         }
    }
}
