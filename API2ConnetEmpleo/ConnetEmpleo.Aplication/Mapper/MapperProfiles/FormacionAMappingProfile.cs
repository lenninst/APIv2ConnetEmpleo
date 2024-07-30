using AutoMapper;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Dtos.Request;

namespace ConnetEmpleo.Aplication.Mapper.MapperProfiles
{
    public class FormacionAMappingProfile : Profile
   {
      public FormacionAMappingProfile()
      {
         //  CreateMap<FormacionAcademica, FormacionAcademicaResponseDto>()
         //  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

         CreateMap<FormacionAcademicaRequestDto, FormacionAcademica>();
      }

   }
}
