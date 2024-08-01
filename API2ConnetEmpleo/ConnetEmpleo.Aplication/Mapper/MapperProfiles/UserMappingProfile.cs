using AutoMapper;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Dtos.Request;

namespace ConnetEmpleo.Aplication.Mapper.MapperProfiles
{
   public class UserMappingProfile : Profile
   {
      public UserMappingProfile()
      {
         CreateMap<UserRequestDto, User>().ReverseMap();
         CreateMap<LoginRequestDto, User>().ReverseMap();

      }
   }
}
