using AutoMapper;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Dtos.Request;

namespace ConnetEmpleo.Aplication.Mapper.MapperProfiles
{
   public class OfertaEMappingProfile : Profile
   {
      public OfertaEMappingProfile()
      {
         CreateMap<OfertaEmpleoRequestDto, OfertasEmpleo>();
      }
   }
}
