using AutoMapper;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Dtos.Response;

namespace ConnetEmpleo.Aplication.Mapper.MapperProfiles
{
   public class OfertaEMappingProfile : Profile
   {
      public OfertaEMappingProfile()
      {
         CreateMap<OfertaEmpleoRequestDto, OfertasEmpleo>();
         CreateMap<OfertasEmpleo, OfertasEmpleoResponseDto>()
             .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => src.EmpresaFkNavigation));

         CreateMap<Empresa, EmpresaResponseDto>();

         CreateMap<OfertasEmpleoResponseDto, OfertasEmpleo>()
             .ForMember(dest => dest.EmpresaFkNavigation, opt => opt.Ignore());
      }
   }
}
