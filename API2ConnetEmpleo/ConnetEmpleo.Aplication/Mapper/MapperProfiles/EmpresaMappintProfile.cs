using AutoMapper;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Dtos.Response;

namespace ConnetEmpleo.Aplication.Mapper.MapperProfiles
{
   public class EmpresaMappintProfile : Profile
   {
      public EmpresaMappintProfile()
      {
      CreateMap<EmpresaResponseDto, Empresa>();
      }
   }
}
