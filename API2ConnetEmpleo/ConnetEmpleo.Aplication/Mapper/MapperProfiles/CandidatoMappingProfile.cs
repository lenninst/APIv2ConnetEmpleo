using AutoMapper;
using CnEmpleo.Infrastructure.Commons.Bases.Response;
using ConnectEmpleo.Domain.Entities;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Dtos.Response;

public class CandidatoMappingProfile : Profile
{
   public CandidatoMappingProfile()
   {
      CreateMap<Candidato, CandidatoResponseDto>()
           .ForMember(dest => dest.ExperienciaLaboral, opt => opt.MapFrom(src => src.ExperienciaLaborals))
           .ForMember(dest => dest.Favoritos, opt => opt.MapFrom(src => src.Favoritos))
           .ForMember(dest => dest.FormacionAcademicas, opt => opt.MapFrom(src => src.FormacionAcademicas))
           .ForMember(dest => dest.Postulaciones, opt => opt.MapFrom(src => src.Postulaciones));

      CreateMap<ExperienciaLaboral, ExperienciaLaboralResponseDto>();
      CreateMap<Favorito, FavoritoResponseDto>();
      CreateMap<FormacionAcademica, FormacionAcademicaResponseDto>();
      CreateMap<Postulacion, PostulacionResponseDto>();

      CreateMap<BaseEntityResponse<Candidato>, BaseEntityResponse<CandidatoResponseDto>>()
          .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

      CreateMap<BaseEntityResponse<CandidatoResponseDto>, BaseEntityResponse<Candidato>>()
          .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

      CreateMap<CandidatoRequestDto, Candidato>()
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
            .ForMember(dest => dest.Nacionalidad, opt => opt.MapFrom(src => src.Nacionalidad))
            .ForMember(dest => dest.Fechanacimiento, opt => opt.MapFrom(src => src.FechaNacimiento))
            .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero))
            .ForMember(dest => dest.Documentoid, opt => opt.MapFrom(src => src.DocumentoId))
            .ForMember(dest => dest.Numerocontacto, opt => opt.MapFrom(src => src.NumeroContacto))
            .ForMember(dest => dest.Lugarderesidencia, opt => opt.MapFrom(src => src.LugarDeResidencia))
            .ForMember(dest => dest.RutasHv, opt => opt.MapFrom(src => src.RutasHv))
            .ForMember(dest => dest.Nombre, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Nombre)));
      ;
   }
}

