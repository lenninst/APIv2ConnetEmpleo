using AutoMapper;
using ConnetEmpleo.Aplication.Mapper;

namespace ConnetEmpleo.Application.Mapper
{
   public static class MappingProfile
   {
      public static MapperConfiguration RegisterMappings()
      {
         return new MapperConfiguration(cfg =>
         {
            cfg.AddProfile<CandidatoMappingProfile>();
            cfg.AddProfile<ExperienciaLMappingProfile>();
         });
      }
   }
}
