﻿using AutoMapper;
using ConnetEmpleo.Aplication.Mapper;
using ConnetEmpleo.Aplication.Mapper.MapperProfiles;

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
            cfg.AddProfile<OfertaEMappingProfile>();
            cfg.AddProfile<PostulacionMappingProfile>();
            cfg.AddProfile<UserMappingProfile>();
         });
      }
   }
}
