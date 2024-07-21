using AutoMapper;
using CnEmpleo.Infrastructure.Commons.Bases.Response;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Dtos.Response;

namespace ConnetEmpleo.Aplication.Mapper
{
   public class ExperienciaLMappingProfile : Profile
   {
      public ExperienciaLMappingProfile()
      {
         CreateMap<ExperienciaLaboral, ExperienciaLaboralResponseDto>();

         CreateMap<BaseEntityResponse<ExperienciaLaboral>, BaseEntityResponse<ExperienciaLaboralResponseDto>>()
             .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

         CreateMap<BaseEntityResponse<ExperienciaLaboral>, BaseEntityResponse<ExperienciaLaboral>>()
             .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

         CreateMap<ExperienciaLaboral, ExperienciaLaboralResponseDto>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));


         CreateMap<ExperienciaLaboralRequestDto, ExperienciaLaboral>();


         CreateMap<ExperienciaLaboral, ExperienciaLaboralResponseDto>();

      }
   }
}
