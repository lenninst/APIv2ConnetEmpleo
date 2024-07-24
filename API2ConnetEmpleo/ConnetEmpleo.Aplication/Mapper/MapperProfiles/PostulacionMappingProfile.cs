using AutoMapper;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Dtos.Request;

namespace ConnetEmpleo.Aplication.Mapper.MapperProfiles
{
   public class PostulacionMappingProfile: Profile
   {
      public PostulacionMappingProfile()
      {
         CreateMap<PostulacionRequestDto, Postulacion>();
      }
   }
}
