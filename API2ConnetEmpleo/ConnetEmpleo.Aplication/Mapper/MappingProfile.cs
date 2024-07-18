using AutoMapper;
using CnEmpleo.Infrastructure.Commons.Bases.Response;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Dtos.Response;

namespace ConnetEmpleo.Aplication.Mapper
{
   public class MappingProfile : Profile
   {
      public MappingProfile()
      {

         CreateMap<Candidato, CandidatoResponseDto>();

         CreateMap<BaseEntityResponse<Candidato>, BaseEntityResponse<CandidatoResponseDto>>()
             .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

         CreateMap<BaseEntityResponse<CandidatoResponseDto>, BaseEntityResponse<Candidato>>()
             .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

         /* CreateMap<BaseEntityResponse<Candidato>
             , BaseEntityResponse<CandidatoResponseDto>>()
             .ReverseMap(); */

         CreateMap<BaseEntityResponse<Empresa>
           , BaseEntityResponse<EmpresaResponseDto>>()
           .ReverseMap();

         CreateMap<BaseEntityResponse<ExperienciaLaboral>
           , BaseEntityResponse<ExperienciaLaboralResponseDto>>()
           .ReverseMap();

         CreateMap<BaseEntityResponse<Favorito>
           , BaseEntityResponse<FavoritoResponseDto>>()
           .ReverseMap();

         CreateMap<BaseEntityResponse<FormacionAcademica>
           , BaseEntityResponse<FormacionAcademicaResponseDto>>()
           .ReverseMap();

         CreateMap<BaseEntityResponse<OfertasEmpleo>
           , BaseEntityResponse<OfertasEmpleoResponseDto>>()
           .ReverseMap();

         CreateMap<BaseEntityResponse<Postulacion>
           , BaseEntityResponse<PostulacionResponseDto>>()
           .ReverseMap();

         CreateMap<BaseEntityResponse<User>
           , BaseEntityResponse<UserResponseDto>>()
           .ReverseMap();

      }
   }
}
