using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Dtos.Response;

namespace ConnetEmpleo.Aplication.Interface
{
   public interface IExperienciaLaboralAplication
   {
      Task<BaseResponse<bool>> AddExperienciaLaboralWithCandidatoId(int id, ExperienciaLaboralRequestDto experienciaLaboralRequestDtol);
   }
}
