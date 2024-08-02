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

      CreateMap<Favorito, FavoritoResponseDto>()
          .ForMember(dest => dest.OfertaEmpleo, opt => opt.MapFrom(src => src.OfertasEmpleosFkNavigation));  // Corrige aquí

      CreateMap<FormacionAcademica, FormacionAcademicaResponseDto>();

      CreateMap<Postulacion, PostulacionResponseDto>()
          .ForMember(dest => dest.OfertaEmpleo, opt => opt.MapFrom(src => src.OfertasEmpleosFkNavigation));  // Asegúrate de que exista

      CreateMap<OfertasEmpleo, OfertasEmpleoResponseDto>()
          .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => src.EmpresaFkNavigation));  // Asegúrate de que exista

      CreateMap<Empresa, EmpresaResponseDto>();


      //CreateMap<Candidato, CandidatoResponseDto>()
      //    .ForMember(dest => dest.ExperienciaLaboral, opt => opt.MapFrom(src => src.ExperienciaLaborals))
      //    .ForMember(dest => dest.Favoritos, opt => opt.MapFrom(src => src.Favoritos))
      //    .ForMember(dest => dest.FormacionAcademicas, opt => opt.MapFrom(src => src.FormacionAcademicas))
      //    .ForMember(dest => dest.Postulaciones, opt => opt.MapFrom(src => src.Postulaciones));

      //CreateMap<ExperienciaLaboral, ExperienciaLaboralResponseDto>();
      //CreateMap<Favorito, FavoritoResponseDto>();
      //CreateMap<FormacionAcademica, FormacionAcademicaResponseDto>();
      //CreateMap<Postulacion, PostulacionResponseDto>();
   }
}

